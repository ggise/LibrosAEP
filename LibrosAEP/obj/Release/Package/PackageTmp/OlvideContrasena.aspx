<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OlvideContrasena.aspx.cs" Inherits="LibrosAEP.OlvideContrasena" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="CuerpoRegistro">
        <div class="FormularioRegistro">
            <h4 style="color: #00ffff">Olvido su contraseña</h4>
            <div class="row">
                <div class="col">

                    <asp:TextBox ID="TxtEmail" class="controls" type="email" placeholder="Ingrese su Email" aria-label="Ingrese Nombre" runat="server" Font-Size="Medium"></asp:TextBox>
                </div>

                <div class="row">
                    <div class="col">
                        <asp:Button ID="BtnAceptar" OnClick="BtnAceptar_Click" Text="Aceptar" CssClass="btn btn-primary" runat="server" ToolTip="Click para darse de alta" />
                    </div>
                    <div class="col">
                        <p><a href="Login.aspx">¿Ya tengo Cuenta?</a></p>
                    </div>
                    <div class="col">
                        <asp:Button Text="Cancelar" CssClass="btn btn-danger" ID="btnCancelar" AutoPostBack="true" OnClick="btnCancelar_Click" runat="server" />
                    </div>
                    <div>
                        <asp:Label ID="LblMensaje" ForeColor="red" runat="server" Visible="false"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
   
</asp:Content>
