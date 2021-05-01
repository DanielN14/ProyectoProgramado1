<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MiCarrito.aspx.cs" Inherits="Proyecto_Programado_1.APP.MiCarrito" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Assets/Styles/styles.css" rel="stylesheet" />
    <link rel="preconnect" href="https://fonts.gstatic.com" />
    <link href="https://fonts.googleapis.com/css2?family=Source+Sans+Pro:ital,wght@0,400;0,600;1,400&display=swap" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.1/css/all.min.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/mdb-ui-kit/3.3.0/mdb.min.css" rel="stylesheet" />
    <link href="../Content/font-awesome.min.css" rel="stylesheet" />
    <script src="../Scripts/jquery-3.0.0.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="https://getbootstrap.com/docs/4.1/assets/js/vendor/popper.min.js"></script>
    <title>Mi carrito</title>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-light">
            <div class="container-fluid">
                <a class="navbar-brand" href="#">
                    <img src="Assets/Images/logo-libreria.png" style="width: 40%; height: 30%; margin-top: -10px;" />
                </a>
                <button class="navbar-toggler" type="button" data-mdb-toggle="collapse" data-mdb-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation"><i class="fas fa-bars"></i></button>
                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                        <li class="nav-item">
                            <a class="nav-link" href="Libros.aspx">Inicio</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="Favoritos.aspx">Favoritos</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link active" href="MiCarrito.aspx">Mi carrito</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="MisCompras.aspx">Mis compras</a>
                        </li>
                    </ul>

                    <div class="d-flex input-group w-auto lign-self-end">
                        <input id="txtBusqueda" runat="server" type="search" class="form-control" placeholder="Buscar..." aria-label="Search" />
                        <asp:Button ID="btnBuscarLibro" class="btn btn-outline-success" runat="server" Text="Buscar" OnClick="btnBuscarLibro_Click" data-mdb-ripple-color="success" />
                    </div>
                </div>
            </div>
        </nav>
        <h3 style="text-align: center; margin-top: 10px">Mi carrito <i class="fa fa-shopping-cart"></i></h3>
        <div class="container-fluid">
            <div class="row mt-3 mb-4">
                <asp:Repeater ID="repMiCarrito" runat="server">
                    <HeaderTemplate>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="card mb-3" style="width: 27rem; height: 100%; box-shadow: 1px 1px 10px #888888; margin-left: 15px; border-radius: 10px;">
                            <div class="row g-0">
                                <div class="col-md-4">
                                    <img src="<%# Eval("ImagenPortada") %>" alt="..." class="img-fluid" style="margin-top: 10px; margin-bottom: 10px; height: 215px; border-radius: 5px;" />
                                </div>
                                <div class="col-md-8">
                                    <div class="card-body btnCards">
                                        <h4 class="card-title mb-3" style="margin-top: -8px; font-size: 19px; font-weight: 600;"><%# Eval("Titulo") %></h4>
                                        <p class="card-text" style="margin-bottom: 2px; font-size: 15.5px;">Autor: <%# Eval("Autor") %></p>
                                        <p class="card-text" style="margin-bottom: 2px; font-size: 15.5px;">Fecha de publicación: <%# Eval("FechaPublicacion").ToString().Substring(0,10) %></p>
                                        <p class="card-text" style="font-size: 15.5px">ISBN: <%# Eval("ISBN")%></p>
                                        <a class="btn btn-outline-danger" onclick="cargarId('<%# Eval("IdCar") %>')" data-toggle="modal" data-target="#CancelDialog" style="position: absolute; bottom: 10px; font-size: 11px; display: inline-block; border-radius: 8px; width: 33%; max-height: 35px;">
                                            <p>Quitar</p>
                                        </a>
                                        <a href="CompraLibro.aspx?idLibro=<%# Eval("Id") %>" class="btn btn-outline-success" style="position: absolute; font-size: 11px; bottom: 10px; right: 10px; display: inline-block; border-radius: 8px; width: 55%; max-height: 35px;">Comprar ₡<%# Eval("Precio") %></a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div class="modal fade" id="CancelDialog" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Quitar del Carrito:
                            <asp:TextBox ID="txtCodigo" runat="server" ReadOnly="true"></asp:TextBox>
                        </h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        ¿Esta seguro que desea quitar el libro del carrito?
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnQuitar" runat="server" Style="float: right" class="btn btn-danger" Text="Aceptar" OnClick="btnQuitar_Click" />
                    </div>
                </div>
            </div>
        </div>
        <div id="divModal"></div>
        <script type="text/javascript" src="../Scripts/App.js"></script>
        <script type="text/javascript" src="../Scripts/MensajeModal.js"></script>
    </form>
</body>
</html>
