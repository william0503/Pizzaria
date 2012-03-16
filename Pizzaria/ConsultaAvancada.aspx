<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultaAvancada.aspx.cs" Inherits="Pizzaria.ConsultaAvancada" ClientIDMode="Static" ViewStateMode="Disabled"%>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server" >
</asp:Content>
   
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <h2>
        Consulta
    </h2>
    <p>
        Pizzas com o ingrendiente:
        <asp:DropDownList ID="DropDownListIngrediente" runat="server" DataTextField="Nome"
                DataValueField="Id">
        </asp:DropDownList>
    </p>
    <div id="divGridConsulta"></div>
    <script src="Scripts/jquery-1.6.4.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.noty.js" type="text/javascript"></script>
    <script src="Scripts/NotyAlert.js" type="text/javascript"></script>
    <script src="Scripts/jquery.quicksearch.js" type="text/javascript"></script>
    <script type="text/javascript">
        $("#DropDownListIngrediente").change(function () {
            CarregarPizzas();
        });

        function CarregarPizzas() {
            var dados = {};
            var request = $.ajax({
                type: "POST",
                url: "GridConsultaAvancada.aspx?ingrediente=" + $("#DropDownListIngrediente").val(),
                data: dados
            });


            request.done(function (data) {
                $("#divGridConsulta").html(data);
                
            });

            request.fail(function (jqXHR, textStatus) {
                NotyAlert("Request failed: " + textStatus, "error");
            });
        }
    </script>

</asp:Content>
