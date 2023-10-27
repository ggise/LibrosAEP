<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListarUsuarios.aspx.cs" Inherits="LibrosAEP.ListarUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <div class="ContenedorPrincipal">
<div class="container-listas">
  <div class="d-flex justify-content-end"style="margin-bottom: 20px">
      </div>
    <table>
        <thead >
      <tr style="color: #000000;background-color:  plum;">
                <th scope="col">Nombre</th>
                <th scope="col">Apellido</th>
                <th scope="col">Email</th>     
                   <th scope="col">Leyendo</th>  
                  <th scope="col">Activo</th>    
                <th scope="col"><svg xmlns="http://www.w3.org/2000/svg" height="2em" viewBox="0 0 576 512"><!--! Font Awesome Free 6.4.0 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license (Commercial License) Copyright 2023 Fonticons, Inc. --><path d="M192 64C86 64 0 150 0 256S86 448 192 448H384c106 0 192-86 192-192s-86-192-192-192H192zm192 96a96 96 0 1 1 0 192 96 96 0 1 1 0-192z"/></svg></th>                              
                <th scope="col"><svg xmlns="http://www.w3.org/2000/svg" height="2em" viewBox="0 0 576 512"><!--! Font Awesome Free 6.4.0 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license (Commercial License) Copyright 2023 Fonticons, Inc. --><path d="M192 64C86 64 0 150 0 256S86 448 192 448H384c106 0 192-86 192-192s-86-192-192-192H192zm192 96a96 96 0 1 1 0 192 96 96 0 1 1 0-192z"/></svg></th>                              
                
            </tr>
            
        </thead>
        <tbody>
            <asp:Repeater runat="server" ID="repRepetidor">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Nombre") %></td>
                        <td><%# Eval("Apellido") %></td>
                         <td><%# Eval("Email") %></td>
                                             
                        <td><%# Eval("Activo")%></td>
                         <td> 
                          
                            <asp:Button Text="Desactivar" Cssclass="btn btn-danger" ID="btnEliminar" OnClientClick="return confirm('Esta seguro de que quiere dejar INACTIVO a este usuario ?');" OnClick="btnEliminar_Click" runat="server" CommandName="UsuarioId" CommandArgument='<%# Eval("Id")%> '/>     
                          </td>
                        <td>
                             <asp:Button Text="Activar" Cssclass="btn btn-success" ID="btnActivar" OnClientClick="return confirm('Esta seguro de quiere ACTIVAR a este usuario?');" OnClick="BtnActivar_Click" runat="server" CommandName="UsuarioId" CommandArgument='<%# Eval("Id")%> '/>  
                          
                         </td>
                         <td>
                        <asp:Button Text="Modificar" Cssclass="btn btn-secondary" ID="btnModificar" AutoPostBack="true" OnClick="btnModificar_Click" runat="server" CommandName="AlbumId" CommandArgument='<%# Eval("Id")%>'/>
                       </td>                     
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
    <asp:Label ID="lblMensaje" ForeColor="red" runat="server" CssClass="message" Visible="false"></asp:Label>
            </div>
         </div>
</asp:Content>
