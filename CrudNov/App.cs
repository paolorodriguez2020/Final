using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrudNov.Entities;

namespace CrudNov
{
    public partial class App : Form
    {
        /*User user;

        public App(User us)
        {
        //  user = us;
        InitializeComponent();

        }
        private void App_Load(object sender, EventArgs e)
        {
        // lblnameB.Text = $"{user.Name}{user.LastName}";
        }
        */
      
        

        public App(){
            InitializeComponent();
            
          
        }

        private void App_Load(object sender, EventArgs e)
        {
           
        }
        
        public void ContarCeldasLlenas()
        {
            int celdasPrimeraColumnaLlenas = 0;

            foreach (DataGridViewRow fila in dataGridView1.Rows)
            {
               // Verifica si el valor de la celda convertido a cadena no está vacío ni es nulo.
                if (fila.Cells[0].Value != null && !string.IsNullOrEmpty(fila.Cells[0].Value.ToString()))
                {
                    celdasPrimeraColumnaLlenas++;
                }
            }

            if (celdasPrimeraColumnaLlenas == 1) 
            {
                lblContador.Text = (celdasPrimeraColumnaLlenas.ToString() + " Persona");
            }
            else
            lblContador.Text = (celdasPrimeraColumnaLlenas.ToString()+" Personas");
        }

      

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrWhiteSpace(txtName.Text) &&
                !string.IsNullOrWhiteSpace(txtLastname.Text) &&
                !string.IsNullOrWhiteSpace(txtAge.Text) &&
                !string.IsNullOrWhiteSpace(txtPhone.Text))
            {

                string nombre, apellido, edad, telefono;


                nombre = txtName.Text;
                apellido = txtLastname.Text;
                edad = txtAge.Text;
                telefono = txtPhone.Text;


                dataGridView1.Rows.Add(nombre, apellido, edad, telefono);

                txtName.Text = "";
                txtLastname.Text = "";
                txtAge.Text = "";
                txtPhone.Text = "";

                ContarCeldasLlenas();


            }
            else
            {
                // Mostrar un mensaje de error indicando que todos los campos deben ser llenados
                MessageBox.Show("Por favor, complete todos los campos.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

           
        }
      

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow filaseleccionada = dataGridView1.SelectedRows[0];
                filaseleccionada.Cells[0].Value = txtName.Text;
                filaseleccionada.Cells[1].Value = txtLastname.Text;
                filaseleccionada.Cells[2].Value = txtAge.Text;
                filaseleccionada.Cells[3].Value = txtPhone.Text;
                dataGridView1.Refresh();
            }
        }
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count) 
            { 
                DataGridViewRow filaseleccionada = dataGridView1.Rows[e.RowIndex];
                txtName.Text = filaseleccionada.Cells[0].Value?.ToString ();
                txtLastname.Text = filaseleccionada.Cells[1].Value?.ToString();
                txtAge.Text = filaseleccionada.Cells[2].Value?.ToString();
                txtPhone.Text = filaseleccionada.Cells[3].Value?.ToString();
                    
            }
        }
        

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = dataGridView1.SelectedRows[0];
                dataGridView1.Rows.Remove(fila);
            }
            else
            {
                MessageBox.Show("Debes seleccionar una fila antes de eliminar");
            }

            ContarCeldasLlenas();
            
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string terminoBusqueda = txtBusqueda.Text.ToLower();

            if (!string.IsNullOrWhiteSpace(terminoBusqueda))
            {
                // Borrar selección actual (si la hay)
                dataGridView1.ClearSelection();

                foreach (DataGridViewRow fila in dataGridView1.Rows)
                {
                    bool encontrado = false;

                    for (int i = 0; i < fila.Cells.Count; i++)
                    {
                        if (fila.Cells[i].Value != null && fila.Cells[i].Value.ToString().ToLower().Contains(terminoBusqueda))
                        {
                            encontrado = true;
                            break;
                        }
                    }

                    if (encontrado)
                    {
                        // Seleccionar la fila que coincide con el término de búsqueda
                        fila.Selected = true;
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Ingrese un término de búsqueda válido.", "Búsqueda Vacía", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

       
    }
}
