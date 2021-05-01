<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompraLibro.aspx.cs" Inherits="Proyecto_Programado_1.APP.CompraLibro" %>

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
    <title>Compra de libro</title>
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
                            <a class="nav-link active" href="Libros.aspx">Inicio</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link active" href="Favoritos.aspx">Favoritos</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link active" href="MiCarrito.aspx">Mi carrito</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link active" href="MisCompras.aspx">Mis compras</a>
                        </li>
                    </ul>
                    <div class="d-flex input-group w-auto lign-self-end">
                        <input id="txtBusqueda" runat="server" type="search" class="form-control" placeholder="Buscar..." aria-label="Search" />
                        <asp:Button ID="btnBuscarLibro" class="btn btn-outline-success" runat="server" Text="Buscar" OnClick="btnBuscarLibro_Click" data-mdb-ripple-color="success" />
                    </div>
                </div>
            </div>
        </nav>
        <asp:Label ID="lblMensaje" Visible="False" runat="server" Font-Size="Large" ForeColor="#993300"></asp:Label>
        <div class="container-fluid">
            <div class="row mt-3 mb-4">
                <div class="col-6">
                    <asp:Repeater ID="repLibro" runat="server">
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <div class="card mb-3" style="max-width: 33rem; box-shadow: 1px 1px 10px #888888; margin-left: 15px; border-radius: 8px; padding: 15px;">
                                <div class="row g-0">
                                    <div class="col-md-4" style="align-content: center">
                                        <img src="<%# Eval("ImagenPortada") %>" alt="..." class="img-fluid" style="border-radius: 5px;" />
                                    </div>
                                    <div class="col-md-8">
                                        <div class="card-body">
                                            <h4 class="card-title mb-4" style="margin-top: -8px; font-size: 20px; font-weight: 600;"><%# Eval("Titulo") %></h4>
                                            <p class="card-text" style="font-size: 15.5px; margin-bottom: 2px;">Autor: <%# Eval("Autor") %></p>
                                            <p class="card-text" style="font-size: 15.5px;">Fecha de publicación: <%# Eval("FechaPublicacion").ToString().Substring(0,10) %></p>
                                            <p class="card-text" style="font-size: 15.5px;">ISBN: <%# Eval("ISBN")%></p>
                                            <a href="Libros.aspx" class="btn btn-outline-success float-right" style="position: absolute; font-size: 14px; bottom: 5px; right: 10px; display: inline-block; border-radius: 10px;">Volver</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                        <FooterTemplate>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
                <div class="col-6">
                    <div class="credit-card-div" style="box-shadow: 1px 1px 10px #888888; position: absolute; padding: 20px; width: 37rem; border-radius: 8px;">
                        <div>
                            <p style="font-weight: 600;">Información general</p>
                            <hr />
                            <div class="row mb-3">
                                <div class="col-md-6">
                                    <input id="txtPais" runat="server" type="text" class="form-control" placeholder="País" />
                                </div>
                                <div class="col-md-6">
                                    <input id="txtEstadoProvincia" runat="server" type="text" class="form-control" placeholder="Estado/Provincia" />
                                </div>
                            </div>
                            <div class="row mb-3">
                                <div class="col-md-12">
                                    <input id="txtDireccionEntrega" runat="server" type="text" class="form-control" placeholder="Dirección de entrega" />
                                </div>
                            </div>
                            <div class="row mb-3">
                                <div class="col-md-7">
                                    <input id="txtCodigoPostal" runat="server" type="text" class="form-control" placeholder="Codigo Postal" />
                                </div>
                                <div class="col-md-5">
                                    <asp:DropDownList ID="DDCantLibros" CssClass="form-select" AutoPostBack="true" runat="server" OnSelectedIndexChanged="DDCantLibros_SelectedIndexChanged">
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>3</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>

                        <div class="credit-card-div">
                            <div class="panel panel-default">
                                <div class="panel-heading">
                                    <p style="font-weight: 600;">Medio de pago</p>
                                    <hr />
                                    <div class="row mb-2">
                                        <div class="col-md-12">
                                            <input id="txtNumTarjeta" runat="server" type="text" class="form-control" placeholder="Número de tarjeta" />
                                        </div>
                                    </div>
                                    <div class="row mb-2">
                                        <div class="col-md-6 col-sm-4 col-xs-4">
                                            <span class="help-block text-muted small-font">Mes de expiración</span>
                                            <select id="selectMesExp" class="form-select" runat="server">
                                                <option value="01">Enero</option>
                                                <option value="02">Febrero </option>
                                                <option value="03">Marzo</option>
                                                <option value="04">Abril</option>
                                                <option value="05">Mayo</option>
                                                <option value="06">Junio</option>
                                                <option value="07">Julio</option>
                                                <option value="08">Agosto</option>
                                                <option value="09">Septiembre</option>
                                                <option value="10">Octubre</option>
                                                <option value="11">Noviembre</option>
                                                <option value="12">Diciembre</option>
                                            </select>
                                        </div>
                                        <div class="col-md-6 col-sm-4 col-xs-4">
                                            <span class="help-block text-muted small-font">Año de expiración</span>
                                            <select id="selectAnoExp" class="form-select" runat="server">
                                                <option value="21">2021</option>
                                                <option value="22">2022</option>
                                                <option value="23">2023</option>
                                                <option value="24">2024</option>
                                                <option value="25">2025</option>
                                                <option value="26">2026</option>
                                                <option value="27">2027</option>
                                                <option value="28">2028</option>
                                                <option value="29">2029</option>
                                                <option value="30">2030</option>
                                            </select>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-4 col-sm-4 col-xs-4">
                                            <span class="help-block text-muted small-font">CCV</span>
                                            <input id="txtCVV" runat="server" type="text" class="form-control" placeholder="CCV" style="max-width: 70px" />
                                        </div>
                                    </div>
                                    <div class="row ">
                                        <div class="col-md-12 col-sm-12 col-xs-12 pad-adjust">
                                            <asp:Button ID="btnComprar" runat="server" class="btn btn-success float-right" Text="Comprar Ahora" OnClick="btnComprar_Click" />
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="divModal"></div>
        <script type="text/javascript" src="../Scripts/MensajeModal.js"></script>
    </form>
</body>
</html>
