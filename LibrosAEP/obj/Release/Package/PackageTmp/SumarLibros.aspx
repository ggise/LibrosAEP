<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SumarLibros.aspx.cs" Inherits="LibrosAEP.SumarLibros" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class= "CuerpoRegistro">
        <div class="FormularioRegistro">
                 <div class="row">
                     
                <h3 style="color: #ffffff">Sumar tus Libros a la Biblioteca AEP</h3>
                <asp:Label ID="LblNombre" runat="server" ForeColor="White" Font-Size="Medium" ></asp:Label>
                </div>
                <div class="row">
                    <asp:TextBox ID="txtSumarLibros" runat="server" type="text" placeholder="Ingrese el titulo del libro" class="controls"></asp:TextBox>
                </div>
                <div class="row">
                <div class="col">
                    <asp:Button ID="BtnAceptar" Text="Aceptar" OnClick="btnEnviar_Click" runat="server" CssClass="btn btn-primary" ToolTip="Click para loguerte" />
                 </div>
                 <div class="col">
                    <asp:Button Text="Cancelar" CssClass="btn btn-danger" ID="Button1" AutoPostBack="true" OnClick="btnCancelar_Click" runat="server" />
                   </div>                                   
                     <asp:Label ID="lblMensaje" ForeColor="Plum" runat="server" Visible="false"></asp:Label>              
              </div>
            </div>
</div>
</asp:Content>
