<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FormAltaLibro.aspx.cs" Inherits="LibrosAEP.FormAltaLibro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="CuerpoRegistro">
        <div class="FormularioRegistro" style="width: 600px; height: 400px; margin-top: 66px">
            <div class="row">
                <asp:Label ID="Lbltitlulo" runat="server" ForeColor="White" Font-Size="Medium"></asp:Label>
            </div>
            <div class="col">
                <div class="row">
                    <div class="col">
                        <asp:TextBox ID="TxtTitulo" runat="server" type="text" placeholder="Ingrese un Titulo" class="controls"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <asp:TextBox ID="TxtImgTapa" class="controls" type="text" placeholder="url  de la tapa" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                </div>

                <div class="row">
                    <div class="col">
                        <asp:DropDownList runat="server" ID="ddlAutor" class="controls" AutoPostBack="true" />
                    </div>
                    <div class="col">
                        <asp:Button ID="btnAgregarAutor" runat="server" OnClick="btnAgregarAutor_Click" Text="+" CssClass="btn btn-primary" />
                        <asp:Label Text="Agregar un Autor Nuevo" runat="server" ForeColor="White" Font-Size="Small"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <asp:DropDownList runat="server" ID="ddlGenero" CssClass="controls" AutoPostBack="true" />
                    </div>
                    <div class="col">
                        <asp:Button ID="btnAgregarGero" runat="server" OnClick="btnAgregarGenero_Click" Text="+" CssClass="btn btn-primary" />
                        <asp:Label Text="Agregar un Genero Nuevo" runat="server" ForeColor="White" Font-Size="Small"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <asp:DropDownList runat="server" ID="ddlUsuario" CssClass="controls" />
                    </div>
                    <div class="col">
                        <asp:Button ID="btnAgregarUsuario" runat="server" OnClick="btnAgregarUsuario_Click" Text="+" CssClass="btn btn-primary" />
                        <asp:Label Text="Agregar una Usuario Nueva" runat="server" ForeColor="White" Font-Size="Small"></asp:Label>
                    </div>
                    <div class="row">
                        <div class="col">
                            <asp:TextBox ID="txtSinopsis" class="controls" type="text" placeholder="Sinopsis" runat="server"></asp:TextBox>
                        </div>

                    </div>
                    <div class="row">
                        <div class="col">
                            <asp:Button ID="BtnAceptar" Text="Aceptar" OnClick="BtnAceptar_Click" runat="server" CssClass="btn btn-primary" ToolTip="Click para loguerte" />
                        </div>
                        <div class="col">
                            <asp:Button Text="Cancelar" CssClass="btn btn-danger" ID="btnCancelar" AutoPostBack="true" OnClick="btnCancelar_Click" runat="server" />
                        </div>
                    </div>
                    <asp:Label ID="LblMensaje" ForeColor="red" runat="server" Visible="false"></asp:Label>

                </div>
            </div>
        </div>
    </div>

</asp:Content>
