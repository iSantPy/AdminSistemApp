using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlAguaPotable
{
    public partial class CustomizeWindow : Form
    {
        public delegate void DataTableUpdateHandler(object sender, DataTableUpdateEventArgs e);

        public event DataTableUpdateHandler DataTableUpdated;

        public CustomizeWindow()
        {
            InitializeComponent();

            clnBtn.Click += ClnBtn_Click;
            acceptBtn.Click += AcceptBtn_Click;
            cantidad.ValueChanged += Cantidad_ValueChanged;
            presentacion.ValueChanged += Cantidad_ValueChanged;
            precioUnitario.ValueChanged += Cantidad_ValueChanged;

        }

        private void Cantidad_ValueChanged(object? sender, EventArgs e)
        {
            int oCantidad = (int)cantidad.Value;
            decimal oPresentacion = presentacion.Value;

            decimal oLitrosTotal = oCantidad * oPresentacion;

            litros.Value = oLitrosTotal;

            decimal oPrecioUnitario = precioUnitario.Value;

            decimal oPrecioTotal = oCantidad * oPrecioUnitario;

            precioTotal.Value = oPrecioTotal;
        }

        private void AcceptBtn_Click(object? sender, EventArgs e)
        { 
            int oCantidad = (int)cantidad.Value;
            decimal oPresentacion = presentacion.Value;
            decimal oLitrosTotal = litros.Value;
            decimal oPrecioUnitario = precioUnitario.Value;
            decimal oPrecioTotal = precioTotal.Value;

            DataTableUpdateEventArgs args = new DataTableUpdateEventArgs(oCantidad, oPresentacion, oLitrosTotal, oPrecioUnitario, oPrecioTotal);

            DataTableUpdated?.Invoke(this, args);
            this.Close();
        }

        private void ClnBtn_Click(object? sender, EventArgs e)
        {
            cantidad.Value = 0;
            presentacion.Value = 0;
            litros.Value = 0;
            precioUnitario.Value = 0;
            precioTotal.Value = 0;
        }
    }

    public class DataTableUpdateEventArgs : EventArgs
    {
        private int cantidad;
        private decimal presentacion;
        private decimal litrosTotal;
        private decimal precioUnitario;
        private decimal precioTotal;

        public DataTableUpdateEventArgs(int cantidad, decimal presentacion, decimal litrosTotal, decimal precioUnitario, decimal precioTotal)
        {
            this.cantidad = cantidad;
            this.presentacion = presentacion;
            this.litrosTotal = litrosTotal;
            this.precioUnitario = precioUnitario;
            this.precioTotal = precioTotal;
        }

        public int Cantidad { get { return cantidad; } }
        public decimal Prepresentacion { get { return presentacion; } }
        public decimal LitrosTotal { get { return litrosTotal; } }
        public decimal PrecioUnitario { get { return precioUnitario; } }  
        public decimal PrecioTotal { get { return precioTotal; } }

    }
}
