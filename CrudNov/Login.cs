using CrudNov.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudNov
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

        }
        User user = new User();

        private void Form1_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
            lblRegister.Visible = false;

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            

            if  (!string.IsNullOrWhiteSpace(txtNameR.Text) &&
                !string.IsNullOrWhiteSpace(txtLastnameR.Text) &&
                !string.IsNullOrWhiteSpace(txtUsernameR.Text)&&
                !string.IsNullOrWhiteSpace(txtPassR.Text)) {

                
                user.Register(txtNameR.Text, txtLastnameR.Text, txtUsernameR.Text, txtPassR.Text);
                lblRegister.Visible = true;
                txtNameR.Clear();
                txtLastnameR.Clear();
                txtUsernameR.Clear();
                txtPassR.Clear();
            }
            else
            {
                // Mostrar un mensaje de error indicando que todos los campos deben ser llenados
                MessageBox.Show("Por favor, complete todos los campos.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            var validate = user.Login(txtUsername.Text, txtPass.Text);

            if (txtUsername.Text != "" && txtPass.Text != "")
            {
                if (validate)
                {
                    this.Hide();
                    App app = new App();
                    app.Show();
                    app.FormClosed += CloseForm;   
                    
                }else lblError.Visible = true;
            }
            else lblError.Visible = true;
        }

        private void CloseForm(object sender, FormClosedEventArgs e){

            this.Show();
            lblRegister.Visible = false;
            lblError.Visible = false;
            txtUsername.Text = "";
            txtPass.Text = "";
            txtUsername.Focus();
        
        
        }

        
    }
}
