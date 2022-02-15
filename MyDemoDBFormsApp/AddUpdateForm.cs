using DemoDbLibrary;
using DemoDbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyDemoDBFormsApp
{
    public partial class AddUpdateForm : Form
    {
        public event RespondToMessageEvent _respondToMessageEvent;
        public AddUpdateForm()
        {
            InitializeComponent();
            _person = new Person();
            this.txtID.Text = "0";
        }

        private Person _person;
        public AddUpdateForm(Person p)
        {
            InitializeComponent();
            _person = p;
            this.txtID.Text = _person.Id.ToString();
            this.txtFirstName.Text = _person.FirstName;
            this.txtLastName.Text = _person.LastName;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.txtFirstName.Text))
            {
                MessageBox.Show("We need to have a first name");
                return;

            }

            using (var db = new MyDbContext(Form1._optionsBuilder.Options))
            {
                string msg = string.Empty;

                if (Convert.ToInt32(txtID.Text) == 0)
                {
                    //add

                    _person.FirstName = txtFirstName.Text;
                    _person.LastName = txtLastName.Text ?? string.Empty;
                    db.People.Add(_person);
                    db.SaveChanges();
                    msg = "Changes Added";

                }
                else
                {
                    //update
                    var personID = Convert.ToInt32(txtID.Text);
                    var person = db.People.SingleOrDefault(x => x.Id == personID);
                    if (person != null)
                    {
                        person.FirstName = txtFirstName.Text;
                        person.LastName = txtLastName.Text;
                        db.SaveChanges();
                        msg = "Changes Updated";
                    }

                }
                
                if (_respondToMessageEvent != null)
                {
                    _respondToMessageEvent.Invoke(msg);
                }
               
            }

            this.Close();
        }
    }
}
