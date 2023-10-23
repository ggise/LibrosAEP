<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DatosUsuario.aspx.cs" Inherits="LibrosAEP.DatosUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class= "CuerpoRegistro">
        <div class="FormularioRegistro">
          <h4 style="color: #00ffff">Mi Perfil</h4>
            <div class="row">
                <div class="col">
                    <asp:Label runat="server" Text="Nombre" ForeColor="White" Font-Size="Medium"></asp:Label>
                </div>
                <div class="col">
                    <asp:TextBox ID="TxtNombre" runat="server" class="controls"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <asp:Label runat="server" Text="Apellido" ForeColor="White" Font-Size="Medium"></asp:Label>
                </div>
                <div class="col">
                    <asp:TextBox ID="TxtApellido" class="controls" aria-label="Apellido" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col">
                    <asp:Label runat="server" Text="Contraseña" ForeColor="White" Font-Size="Medium"></asp:Label>
                </div>
                <div class="col">
                    <asp:TextBox ID="TxtPass" CssClass="controls" type="Pass" aria-label="Pass" runat="server" />
                </div>
            </div>

            <div class="row">
                <div class="col">
                    <asp:Button ID="BtnAceptar" Text="GUARDAR CAMBIOS" OnClick="BtnAceptar_Click" runat="server" CssClass="btn btn-primary" />
                </div>
                <div class="col">
                    <asp:Button ID="BtnCancelar" Text="CANCELAR" OnClick="BtnCancelar_Click" runat="server" CssClass="btn btn-danger" />
                </div>
                <asp:Label ID="LblMensaje" ForeColor="red" runat="server" Visible="false"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
