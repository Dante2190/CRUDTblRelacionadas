using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRUDTblRelacionadas.CapaDatos;

namespace CRUDTblRelacionadas.CapaPresentacion
{
    public partial class PRODUCTOS : Form
    {
        ClsProductos objproducto = new ClsProductos();
        string Operacion = "Insertar";
        string idprod;
        public PRODUCTOS()
        {
            InitializeComponent();
        }

        private void PRODUCTOS_Load(object sender, EventArgs e)
        {
            ListarCategorias();
            ListarMarcas();
            ListarProductos();
        }

        private void ListarCategorias()
        {
            ClsProductos objProd = new ClsProductos();
            cmbCategoria.DataSource = objProd.ListarCategorias();
            cmbCategoria.DisplayMember = "CATEGORIA";
            cmbCategoria.ValueMember = "IDCATEG";
        }
        private void ListarMarcas()
        {
            ClsProductos objProd = new ClsProductos();
            cmbMarcas.DataSource = objProd.ListarMarcas();
            cmbMarcas.DisplayMember = "MARCA";
            cmbMarcas.ValueMember = "IDMARCA";
        }

        private void ListarProductos()
        {
            ClsProductos objprod = new ClsProductos();
            dataGridView1.DataSource = objprod.ListarProductos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ClsProductos objproducto = new ClsProductos();
            if (Operacion == "Insertar")
            {
                objproducto.InsertarProductos(
                    Convert.ToInt32(cmbCategoria.SelectedValue),
                    Convert.ToInt32(cmbMarcas.SelectedValue),
                    txtDescrip.Text,
                    Convert.ToDouble(txtPrecio.Text)
                    );
                MessageBox.Show("Se inserto correctamente");
            }
            else if (Operacion == "Editar")
            {
                objproducto.EditarProductos(Convert.ToInt32(idprod),
                    Convert.ToInt32(cmbCategoria.SelectedValue),
                    Convert.ToInt32(cmbMarcas.SelectedValue),
                    txtDescrip.Text,
                    Convert.ToDouble(txtPrecio.Text));

                Operacion = "Insertar";
                MessageBox.Show("Se edito correctamente");

            }

            ListarProductos();
            LimpiarFormulario();

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                Operacion = "Editar";

                Operacion = "Editar";
                cmbCategoria.Text = dataGridView1.CurrentRow.Cells["CATEGORIA"].Value.ToString();
                cmbMarcas.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtDescrip.Text = dataGridView1.CurrentRow.Cells["DESCRIPCION"].Value.ToString();
                txtPrecio.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                idprod = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();

                /* objproducto._Idprod = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                 objproducto.EliminarProducto();
                 MessageBox.Show("Se elimino satisfactoriamente");
                 ListarProductos();*/
            }
            else
                MessageBox.Show("Seleccione una fila");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                objproducto.EliminarProducto(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                
                MessageBox.Show("Se elimino satisfactoriamente");
                ListarProductos();
            }
            else
                MessageBox.Show("Seleccione una fila");
        }

        private void LimpiarFormulario()
        {
           // cmbCategoria.DataSource = null;
           // cmbMarcas.DataSource = null;
            txtDescrip.Clear();
            txtPrecio.Clear();
        }
    }
}
