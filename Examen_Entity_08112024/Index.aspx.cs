using Examen_Entity_08112024.Context;
using Examen_Entity_08112024.Manager;
using Examen_Entity_08112024.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Examen_Entity_08112024
{
    public partial class Index : System.Web.UI.Page
    {
        // Instanciar la conexion a la base de datos
        private dbContext _context;
        private PersonaManager _personaManager;
        private VehiculoManager _vehiculoManager;
        private MultaManager _multaManager;
        private AccidenteManager _accidenteManager;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Inicializar la conexión a la base de datos
            _context = new dbContext();

            // Inicializar los managers de las entidades
            _personaManager = new PersonaManager(_context);
            _vehiculoManager = new VehiculoManager(_context);

            //cargar datos cliente
            BindPersonasGrid();

            //cargar datos vehiculos
            BindVehiculosGrid();

            BindPersonasDropDown();

            //cargar datos multa

            //cargar datos accidente
        }

        protected void btnAgregarPersona_Click(object sender, EventArgs e)
        {
            var persona = new Persona
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Direccion = txtDireccion.Text,
                Poblacion = txtPoblacion.Text,
                Telefono = txtTelefono.Text,
                DNI = txtDNI.Text,
            };

            _personaManager.AddPersona(persona);
            BindPersonasGrid();
        }

        protected void btnAgregarVehiculo_Click(object sender, EventArgs e)
        {
            var vehiculo = new Vehiculo
            {
                Matricula = txtMatricula.Text,
                Marca = txtMarca.Text,
                Modelo = txtModelo.Text,
                PersonaId = Convert.ToInt32(ddlPersona.SelectedValue)
            };

            _context.Vehiculos.Add(vehiculo);
            _context.SaveChanges();
            BindVehiculosGrid();
        }

        protected void btnAgregarMulta_Click(object sender, EventArgs e)
        {
            var multa = new Multa
            {
                FechaHora = Convert.ToDateTime(txtFechaHora.Text),
                Lugar = txtLugar.Text,
                Importe = Convert.ToDecimal(txtImporte.Text),
                NumeroRegistro = Convert.ToInt32(txtNumeroRegistro.Text),
                PersonaId = Convert.ToInt32(ddlMultaPersona.SelectedValue),
                VehiculoId = Convert.ToInt32(ddlMultaVehiculo.SelectedValue)
            };

            _context.Multas.Add(multa);
            _context.SaveChanges();
            BindMultasGrid();
        }

        //*****CRUD DE PERSONAS****/

        private void BindPersonasGrid()
        {
            gvPersonas.DataSource = _personaManager.GetAllPersonas();
            gvPersonas.DataBind();
        }

        protected void gvPersonas_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvPersonas.EditIndex = e.NewEditIndex;
            BindPersonasGrid();
        }

        protected void gvPersonas_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvPersonas.EditIndex = -1;
            BindPersonasGrid();
        }

        protected void gvPersonas_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvPersonas.Rows[e.RowIndex];
            int personaId = Convert.ToInt32(gvPersonas.DataKeys[e.RowIndex].Value);
            var persona = _personaManager.GetPersonaById(personaId);

            if (persona != null)
            {
                persona.Nombre = ((TextBox)row.Cells[1].Controls[0]).Text;
                persona.Apellido = ((TextBox)row.Cells[2].Controls[0]).Text;
                persona.Direccion = ((TextBox)row.Cells[3].Controls[0]).Text;
                persona.Poblacion = ((TextBox)row.Cells[4].Controls[0]).Text;
                persona.Telefono = ((TextBox)row.Cells[5].Controls[0]).Text;
                persona.DNI = ((TextBox)row.Cells[6].Controls[0]).Text;
                persona.Rol = ((TextBox)row.Cells[7].Controls[0]).Text;

                _personaManager.UpdatePersona(persona);
                gvPersonas.EditIndex = -1;
                BindPersonasGrid();
            }
        }

        protected void gvPersonas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int personaId = Convert.ToInt32(gvPersonas.DataKeys[e.RowIndex].Value);
            _personaManager.DeletePersona(personaId);
            BindPersonasGrid();
        }


        /*****CRUD DE VEHICULOS****/

        //desplegable para el formulario
        private void BindPersonasDropDown()
        {
            ddlPersona.DataSource = _context.Personas.ToList();
            ddlPersona.DataTextField = "Nombre";
            ddlPersona.DataValueField = "PersonaId";
            ddlPersona.DataBind();
        }

        private void BindVehiculosGrid()
        {
            gvVehiculos.DataSource = _vehiculoManager.GetAllVehiculos();
            gvVehiculos.DataBind();
        }

        protected void gvVehiculos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvVehiculos.EditIndex = e.NewEditIndex;
            BindVehiculosGrid();

            // Obtener la fila en edición
            GridViewRow row = gvVehiculos.Rows[e.NewEditIndex];

            // Encontrar el DropDownList y cargar los datos
            DropDownList ddlPersonaId = (DropDownList)row.FindControl("ddlPersona");
            ddlPersonaId.DataSource = _context.Personas.ToList();
            ddlPersonaId.DataTextField = "Nombre";
            ddlPersonaId.DataValueField = "PersonaId";
            ddlPersonaId.DataBind();

            // Establecer el valor seleccionado según el valor actual de PersonaId
            int personaId = Convert.ToInt32(DataBinder.Eval(row.DataItem, "PersonaId"));
            ddlPersonaId.SelectedValue = personaId.ToString();
        }

        protected void gvVehiculos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvVehiculos.EditIndex = -1;
            BindVehiculosGrid();
        }

        protected void gvVehiculos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvVehiculos.Rows[e.RowIndex];
            int vehiculoId = Convert.ToInt32(gvVehiculos.DataKeys[e.RowIndex].Value);
            var vehiculo = _vehiculoManager.GetVehiculoById(vehiculoId);

            if (vehiculo != null)
            {
                vehiculo.Matricula = ((TextBox)row.Cells[1].Controls[0]).Text;
                vehiculo.Marca = ((TextBox)row.Cells[2].Controls[0]).Text;
                vehiculo.Modelo = ((TextBox)row.Cells[3].Controls[0]).Text;

                // Obtener el valor seleccionado del DropDownList
                DropDownList ddlPersonaId = (DropDownList)row.FindControl("ddlPersona");
                vehiculo.PersonaId = Convert.ToInt32(ddlPersonaId.SelectedValue);

                _vehiculoManager.UpdateVehiculo(vehiculo);
                gvVehiculos.EditIndex = -1;
                BindVehiculosGrid();
            }
        }

        protected void gvVehiculos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int vehiculoId = Convert.ToInt32(gvVehiculos.DataKeys[e.RowIndex].Value);
            _vehiculoManager.DeleteVehiculo(vehiculoId);
            BindVehiculosGrid();
        }


        /*****CRUD DE MULTAS****/

        //cargar usuario formulario multas 
        private void BindPersonasMultasDropDown()
        {
                   
            ddlMultaPersona.DataSource = _context.Personas.ToList();
            ddlMultaPersona.DataTextField = "Nombre";
            ddlMultaPersona.DataValueField = "PersonaId";
            ddlMultaPersona.DataBind();
        }

        //cargar vehiculos formulario multas
        private void BindVehiculosMultasDropDown()
        {
            ddlMultaVehiculo.DataSource = _context.Vehiculos.ToList();
            ddlMultaVehiculo.DataTextField = "Matricula";
            ddlMultaVehiculo.DataValueField = "VehiculoId";
            ddlMultaVehiculo.DataBind();
        }

        //Cargar datos multas
        private void BindMultasGrid()
        {
            gvMultas.DataSource = _multaManager.GetAllMultas();
            gvMultas.DataBind();
        }

        protected void gvMultas_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvMultas.EditIndex = e.NewEditIndex;
            BindMultasGrid();

            // Obtener la fila en edición
            GridViewRow row = gvMultas.Rows[e.NewEditIndex];

            // Encontrar los DropDownList y cargar los datos
            DropDownList ddlPersonaId = (DropDownList)row.FindControl("ddlMultaPersona");
            ddlPersonaId.DataSource = _context.Personas.ToList();
            ddlPersonaId.DataTextField = "Nombre";
            ddlPersonaId.DataValueField = "PersonaId";
            ddlPersonaId.DataBind();

            DropDownList ddlVehiculoId = (DropDownList)row.FindControl("ddlMultaVehiculo");
            ddlVehiculoId.DataSource = _context.Vehiculos.ToList();
            ddlVehiculoId.DataTextField = "Matricula";
            ddlVehiculoId.DataValueField = "VehiculoId";
            ddlVehiculoId.DataBind();

            // Establecer los valores seleccionados según los valores actuales de PersonaId y VehiculoId
            int personaId = Convert.ToInt32(DataBinder.Eval(row.DataItem, "PersonaId"));
            ddlPersonaId.SelectedValue = personaId.ToString();

            int vehiculoId = Convert.ToInt32(DataBinder.Eval(row.DataItem, "VehiculoId"));
            ddlVehiculoId.SelectedValue = vehiculoId.ToString();
        }

        protected void gvMultas_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvMultas.EditIndex = -1;
            BindMultasGrid();
        }

        protected void gvMultas_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvMultas.Rows[e.RowIndex];
            int multaId = Convert.ToInt32(gvMultas.DataKeys[e.RowIndex].Value);
            var multa = _multaManager.GetMultaById(multaId);

            if (multa != null)
            {
                multa.FechaHora = Convert.ToDateTime(((TextBox)row.Cells[1].Controls[0]).Text);
                multa.Lugar = ((TextBox)row.Cells[2].Controls[0]).Text;
                multa.Importe = Convert.ToDecimal(((TextBox)row.Cells[3].Controls[0]).Text);
                multa.NumeroRegistro = Convert.ToInt32(((TextBox)row.Cells[4].Controls[0]).Text);

                // Obtener los valores seleccionados de los DropDownList
                DropDownList ddlPersonaId = (DropDownList)row.FindControl("ddlMultaPersona");
                multa.PersonaId = Convert.ToInt32(ddlPersonaId.SelectedValue);

                DropDownList ddlVehiculoId = (DropDownList)row.FindControl("ddlMultaVehiculo");
                multa.VehiculoId = Convert.ToInt32(ddlVehiculoId.SelectedValue);

                _multaManager.UpdateMulta(multa);
                gvMultas.EditIndex = -1;
                BindMultasGrid();
            }
        }

        protected void gvMultas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int multaId = Convert.ToInt32(gvMultas.DataKeys[e.RowIndex].Value);
            _multaManager.DeleteMulta(multaId);
            BindMultasGrid();
        }

        /*****CRUD DE ACCIDENTES****/

        /*****CRUD DE ACCIDENTES****/

        private void BindAccidentesGrid()
        {
            gvAccidentes.DataSource = _accidenteManager.GetAllAccidentes();
            gvAccidentes.DataBind();
        }

        protected void btnAgregarAccidente_Click(object sender, EventArgs e)
        {
            var accidente = new Accidente
            {
                FechaHora = DateTime.Parse(txtFechaHora.Text),
                Lugar = txtLugar.Text,
                NumeroRegistro = int.Parse(txtNumeroRegistro.Text)
            };

            _accidenteManager.AddAccidente(accidente);
            BindAccidentesGrid();
        }

        protected void gvAccidentes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvAccidentes.EditIndex = e.NewEditIndex;
            BindAccidentesGrid();
        }

        protected void gvAccidentes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvAccidentes.EditIndex = -1;
            BindAccidentesGrid();
        }

        protected void gvAccidentes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvAccidentes.Rows[e.RowIndex];
            int accidenteId = Convert.ToInt32(gvAccidentes.DataKeys[e.RowIndex].Value);
            var accidente = _accidenteManager.GetAccidenteById(accidenteId);

            if (accidente != null)
            {
                accidente.FechaHora = DateTime.Parse(((TextBox)row.Cells[1].Controls[0]).Text);
                accidente.Lugar = ((TextBox)row.Cells[2].Controls[0]).Text;
                accidente.NumeroRegistro = int.Parse(((TextBox)row.Cells[3].Controls[0]).Text);

                _accidenteManager.UpdateAccidente(accidente);
                gvAccidentes.EditIndex = -1;
                BindAccidentesGrid();
            }
        }

        protected void gvAccidentes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int accidenteId = Convert.ToInt32(gvAccidentes.DataKeys[e.RowIndex].Value);
            _accidenteManager.DeleteAccidente(accidenteId);
            BindAccidentesGrid();
        }
    }
}


