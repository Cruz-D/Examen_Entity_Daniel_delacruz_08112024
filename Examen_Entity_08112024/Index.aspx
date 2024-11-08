<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Examen_Entity_08112024.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
<link href="IndexStyle.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css" rel="stylesheet" /> 

</head>
<body>
    <form id="form1" runat="server">

        <div class="parent">
            <%-- Tabla Clientes --%>
            <div class="div1">
                <asp:GridView ID="gvPersonas" runat="server" CssClass="table table-striped table-bordered" AutoGenerateColumns="False" DataKeyNames="PersonaId"
                    OnRowEditing="gvPersonas_RowEditing"
                    OnRowCancelingEdit="gvPersonas_RowCancelingEdit"
                    OnRowUpdating="gvPersonas_RowUpdating"
                    OnRowDeleting="gvPersonas_RowDeleting">
                    <Columns>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                        <asp:BoundField DataField="Direccion" HeaderText="Dirección" />
                        <asp:BoundField DataField="Poblacion" HeaderText="Población" />
                        <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                        <asp:BoundField DataField="DNI" HeaderText="DNI" />
                        <asp:BoundField DataField="Rol" HeaderText="Rol" />
                        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView>
            </div>

            <%-- Formulario Clientes --%>
            <div class="div2">

                <div class="card">
                    <div class="card-header">
                        Añadir una Persona
                    </div>
                    <div class="card-body">
                        <div class="form-group">
                            <label for="txtNombre" class="form-label">Nombre</label>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" Placeholder="Nombre"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="txtApellido" class="form-label">Apellido</label>
                            <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" Placeholder="Apellido"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="txtDireccion" class="form-label">Dirección</label>
                            <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" Placeholder="Dirección"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="txtPoblacion" class="form-label">Población</label>
                            <asp:TextBox ID="txtPoblacion" runat="server" CssClass="form-control" Placeholder="Población"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="txtTelefono" class="form-label">Teléfono</label>
                            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" Placeholder="Teléfono"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="txtDNI" class="form-label">DNI</label>
                            <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control" Placeholder="DNI"></asp:TextBox>
                        </div>
                        <asp:Button ID="btnAgregarPersona" runat="server" Text="Agregar Persona" CssClass="btn btn-primary mt-1" OnClick="btnAgregarPersona_Click" />
                    </div>
                </div>

            </div>

            <%-- Tabla Vehiculos --%>
            <div class="div3">
                <asp:GridView ID="gvVehiculos" runat="server" CssClass="table table-striped table-bordered" AutoGenerateColumns="False" DataKeyNames="VehiculoId"
                    OnRowEditing="gvVehiculos_RowEditing"
                    OnRowCancelingEdit="gvVehiculos_RowCancelingEdit"
                    OnRowUpdating="gvVehiculos_RowUpdating"
                    OnRowDeleting="gvVehiculos_RowDeleting" >
                    <Columns>
                        <asp:BoundField DataField="VehiculoId" HeaderText="VehiculoId" ReadOnly="true" />
                        <asp:BoundField DataField="Matricula" HeaderText="Matrícula" />
                        <asp:BoundField DataField="Marca" HeaderText="Marca" />
                        <asp:BoundField DataField="Modelo" HeaderText="Modelo" />
                        <asp:TemplateField HeaderText="ID de Persona">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlPersona" runat="server" CssClass="form-control"></asp:DropDownList>
                        </EditItemTemplate>
                        <ItemTemplate>
                            <%# Eval("PersonaId") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView>
            </div>

            <%-- Formulario Vehiculos --%>
            <div class="div4">

                <div class="card">
                    <div class="card-header">
                        Añadir un Vehículo
                    </div>
                    <div class="card-body">
                        <div class="form-group">
                            <label for="txtMatricula" class="form-label">Matrícula</label>
                            <asp:TextBox ID="txtMatricula" runat="server" CssClass="form-control" Placeholder="Matrícula"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="txtMarca" class="form-label">Marca</label>
                            <asp:TextBox ID="txtMarca" runat="server" CssClass="form-control" Placeholder="Marca"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="txtModelo" class="form-label">Modelo</label>
                            <asp:TextBox ID="txtModelo" runat="server" CssClass="form-control" Placeholder="Modelo"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <div class="form-group">
                                <label for="ddlPersona" class="form-label">ID de Persona</label>
                                <asp:DropDownList ID="ddlPersona" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <asp:Button ID="btnAgregarVehiculo" runat="server" Text="Agregar Vehículo" CssClass="btn btn-primary mt-1" OnClick="btnAgregarVehiculo_Click" />
                    </div>
                </div>

            </div>

            <%-- Tabla Multas --%>
            <div class="div5">
                <asp:GridView ID="gvMultas" runat="server" CssClass="table table-striped table-bordered" AutoGenerateColumns="False" DataKeyNames="MultaId">
                    <Columns>
                        <asp:BoundField DataField="MultaId" HeaderText="ID" ReadOnly="True" />
                        <asp:BoundField DataField="FechaHora" HeaderText="Fecha y Hora" DataFormatString="{0:dd/MM/yyyy HH:mm}" />
                        <asp:BoundField DataField="Lugar" HeaderText="Lugar" />
                        <asp:BoundField DataField="Importe" HeaderText="Importe" DataFormatString="{0:C}" />
                        <asp:BoundField DataField="NumeroRegistro" HeaderText="Número de Registro" />
                        <asp:BoundField DataField="PersonaId" HeaderText="ID de Persona" />
                        <asp:BoundField DataField="VehiculoId" HeaderText="ID de Vehículo" />
                        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                    </Columns>
                </asp:GridView>
            </div>

            <%-- Formulario Multas --%>
            <div class="div6">
                <div class="card">
                    <div class="card-header">
                        Añadir una Multa
                    </div>
                    <div class="card-body">
                        <div class="form-group">
                            <label for="txtFechaHora" class="form-label">Fecha y Hora</label>
                            <asp:TextBox ID="txtFechaHora" runat="server" CssClass="form-control" Placeholder="Fecha y Hora" TextMode="DateTimeLocal"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="txtLugar" class="form-label">Lugar</label>
                            <asp:TextBox ID="txtLugar" runat="server" CssClass="form-control" Placeholder="Lugar"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="txtImporte" class="form-label">Importe</label>
                            <asp:TextBox ID="txtImporte" runat="server" CssClass="form-control" Placeholder="Importe"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="txtNumeroRegistro" class="form-label">Número de Registro</label>
                            <asp:TextBox ID="txtNumeroRegistro" runat="server" CssClass="form-control" Placeholder="Número de Registro"></asp:TextBox>
                        </div>
                        
                        <div class="form-group">
                            <label for="ddlPersonaIdMulta" class="form-label">ID de Persona</label>
                            <asp:DropDownList ID="ddlMultaPersona" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="ddlVehiculoId" class="form-label">ID de Vehículo</label>
                            <asp:DropDownList ID="ddlMultaVehiculo" runat="server" CssClass="form-control"></asp:DropDownList>
                       
                        <asp:Button ID="btnAgregarMulta" runat="server" Text="Agregar Multa" CssClass="btn btn-primary mt-1" OnClick="btnAgregarMulta_Click" />
                    </div>
                </div>
                </div>
            </div>
        
           <!-- Tabla Accidentes -->
            <div class="div6">
                <div class="card">
    <div class="card-header">
        Añadir un Accidente
    </div>
    <div class="card-body">
        <div class="form-group">
            <label for="txtFechaHora" class="form-label">Fecha y Hora</label>
            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" Placeholder="dd/MM/yyyy HH:mm"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtLugar" class="form-label">Lugar</label>
            <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" Placeholder="Lugar"></asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtNumeroRegistro" class="form-label">Número de Registro</label>
            <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" Placeholder="Número de Registro"></asp:TextBox>
        </div>
        <asp:Button ID="btnAgregarAccidente" runat="server" Text="Agregar Accidente" CssClass="btn btn-primary mt-1" OnClick="btnAgregarAccidente_Click" />
    </div>
</div>
            </div>

            <!-- Formulario Accidentes -->
            <div class="div7">
                

                <asp:GridView ID="gvAccidentes" runat="server" CssClass="table table-striped table-bordered" AutoGenerateColumns="False" DataKeyNames="AccidenteId"
    OnRowEditing="gvAccidentes_RowEditing"
    OnRowCancelingEdit="gvAccidentes_RowCancelingEdit"
    OnRowUpdating="gvAccidentes_RowUpdating"
    OnRowDeleting="gvAccidentes_RowDeleting">
    <Columns>
        <asp:BoundField DataField="AccidenteId" HeaderText="AccidenteId" ReadOnly="true" />
        <asp:BoundField DataField="FechaHora" HeaderText="Fecha y Hora" DataFormatString="{0:dd/MM/yyyy HH:mm}" />
        <asp:BoundField DataField="Lugar" HeaderText="Lugar" />
        <asp:BoundField DataField="NumeroRegistro" HeaderText="Número de Registro" />
        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
    </Columns>
</asp:GridView>
            </div>
        </div>
    </form>

</body>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js"></script>
</html>
