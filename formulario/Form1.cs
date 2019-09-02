using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace formulario
{
    public partial class Tienda : Form
    {
        Cliente clientes = new Cliente();

        public Tienda()
        {
            InitializeComponent();
        }



        void Clear()
        {
            txtCedula.Text = txtApellido.Text = txtNombre.Text = txtDireccion.Text = "";
            btnelinimar.Enabled = false;
            btnEditar.Enabled = false;
            btnGuardar.Enabled = true;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Clear();
            Publicar();
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using (Conexionbases Db = new Conexionbases())
            {

                var IdCliente = txtCedula.Text.Trim();
                var validar = Db.Cliente.Count(a => a.IdCliente == IdCliente);
                if (validar == 0)
                {
                    clientes.IdCliente = txtCedula.Text.Trim();
                    clientes.Nombres = txtNombre.Text.Trim();
                    clientes.Apellidos = txtApellido.Text.Trim();
                    clientes.Dirección = txtDireccion.Text.Trim();


                    Db.Cliente.Add(clientes);
                    Db.SaveChanges();

                    Publicar();
                    Clear();
                    MessageBox.Show("Se guardo correctamente el Cliente");
                }
                else
                {
                    MessageBox.Show("El cliente con ese numero de cedula ya esta creado");
                }
            }
                
        }

        private void btnelinimar_Click(object sender, EventArgs e)
        {
            var Cedula = txtCedula.Text.Trim();

            using (Conexionbases Db = new Conexionbases())
            {
                clientes = Db.Cliente.Where(a => a.IdCliente == Cedula).FirstOrDefault();
                Db.Cliente.Remove(clientes);
                Db.SaveChanges();
            }
            Publicar();
            Clear();
            MessageBox.Show("Se Borro Cliente Correctamente Cliente");
        }


        void Publicar()
        {
            using (Conexionbases Db = new Conexionbases())
            {
                DataMostrar.DataSource = Db.Cliente.ToList();
            }
        }

        private void DataMostrar_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DataMostrar.CurrentRow.Index != -1)
            {
                clientes.IdCliente = Convert.ToString(DataMostrar.CurrentRow.Cells["Cedula"].Value);

                using (Conexionbases Db = new Conexionbases() )
                {
                    clientes = Db.Cliente.Where(a => a.IdCliente == clientes.IdCliente).FirstOrDefault();
                    txtCedula.Text = clientes.IdCliente;
                    txtNombre.Text = clientes.Nombres;
                    txtApellido.Text = clientes.Apellidos;
                    txtDireccion.Text = clientes.Dirección;



                }

                btnelinimar.Enabled = true;
                btnEditar.Enabled = true;
                btnGuardar.Enabled = false;

            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            using (Conexionbases Db = new Conexionbases())
            {

                var IdCliente = txtCedula.Text.Trim();
                clientes = Db.Cliente.Where(a => a.IdCliente == IdCliente).FirstOrDefault();


             clientes.Nombres = txtNombre.Text.Trim();
            clientes.Apellidos = txtApellido.Text.Trim();
            clientes.Dirección = txtDireccion.Text.Trim();
           
               
            
                Db.SaveChanges();
            }
            Publicar();
            Clear();
            btnGuardar.Enabled = true;
            MessageBox.Show("Se actulizo correctmante");
        }

    }
}


