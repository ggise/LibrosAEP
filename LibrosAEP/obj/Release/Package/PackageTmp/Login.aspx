<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LibrosAEP.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class= "CuerpoRegistro">
        <div class="FormularioRegistro" >
            <div class="row">
                <h4 style="color: #ffffff">INGRESE SU CUENTA</h4>
                </div>
                <div class="row">
                <label for="exampleFormControlInput1" class="form-label">Email</label>
                <asp:TextBox ID="TxtEmail" CssClass="controls" type="Mail"  runat="server"></asp:TextBox>
                </div>
                <div class="row">
                <label for="exampleFormControlInput1" class="form-label">Password</label>
                <asp:TextBox ID="TxtPass" CssClass="controls" type="password"   runat="server"></asp:TextBox>
                </div>
                <div class="row">
                <div id="passwordHelpBlock" class="form-text" >
                Tu password deber tener entre 3 y 8 caracteres.
               </div>
                </div>
               <div class="row">
               <div class="col">
                <asp:Button ID="BtnAceptar" Text="  Entrar  " OnClick="BtnAceptar_Click" runat="server" CssClass="btn btn-primary" ToolTip="Click para loguerte" />
                </div>
                <div class="col">
                <asp:Button Text="Cancelar" CssClass="btn btn-danger" ID="btnCancelar" AutoPostBack="true" OnClick="btnCancelar_Click" runat="server" />
                </div>
                   </div>
                <div class="row">
               <div class="col">
               <p><a href="RegistrarCuenta.aspx" aria-describedby="cxcxxcxc">Registrar Cuenta Nueva</a></p>
                </div>
               <p><a href="OlvideContrasena.aspx" aria-describedby="cxcxxcxc">Olvide contraseña</a></p>
                 </div>
           </div>
        </div>
        
 



</asp:Content>
