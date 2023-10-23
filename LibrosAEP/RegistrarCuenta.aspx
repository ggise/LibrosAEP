<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarCuenta.aspx.cs" Inherits="LibrosAEP.RegistrarCuenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
 <div class= "CuerpoRegistro">
        <div class="FormularioRegistro" >
                 <h4 style="color: #00ffff">Formulario Registro</h4>
             <div class="row"> 
               <div class="col">
                <asp:TextBox ID="TxtNombre" CssClass="controls" type="text" placeholder="Ingrese su Nombre"  runat="server" Font-Size="Medium"></asp:TextBox>
                </div>
                <div class="col">
                <asp:TextBox ID="TxtApellido" class="controls" type="text" placeholder="Ingrese su Apellido" aria-label="Ingrese Nombre" runat="server" Font-Size="Medium"></asp:TextBox>
                </div>
                 </div>
               <div class="row"> 
               <div class="col">
                <asp:TextBox ID="TxtEmail" class="controls" type="email" placeholder="Ingrese su Email" aria-label="Ingrese Nombre" runat="server" Font-Size="Medium"></asp:TextBox>
              </div>
               <div class="col">
                   <asp:TextBox ID="TxtPass" class="controls" MaxLength="8"  type="password" placeholder=" Entre 3 y 8 caracteres." aria-label="Ingrese Nombre" runat="server" Font-Size="Medium"></asp:TextBox>
                </div>
                    </div>
                
               <div class="row"> 
               <div class="col">
                <asp:Button ID="BtnAgregar" OnClick="BtnAgregar_Click" Text="Registrar" CssClass="btn btn-primary" runat="server" ToolTip="Click para darse de alta" />
                </div>
                <div class="col">
               <p><a href="Login.aspx">¿Ya tengo Cuenta?</a></p>
               </div>
               <div class="col">
               <asp:Button Text="Cancelar" CssClass="btn btn-danger" ID="btnCancelar" AutoPostBack="true" OnClick="btnCancelar_Click" runat="server" />
               </div>
                <asp:Label ID="LblMensaje" ForeColor="red" runat="server" Visible="false"></asp:Label>
               
                </div>
            </div>
        </div>



</asp:Content>
