<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Pizzaria._Default" ClientIDMode="Static"
    ViewStateMode="Disabled" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Pizzaria!
    </h2>
    <div id="divPizza">
        <p>
            Nova Pizza</p>
        <p>
            <b>Nome da Pizza:</b>
            <input id="txtNome" type="text" />
        </p>
        <p>
            Ingredientes:
        </p>
        <%--<p><asp:TextBox ID="txtIngrediente1" runat="server"></asp:TextBox></p>
        <p><asp:TextBox ID="txtIngrediente2" runat="server"></asp:TextBox></p>    
        <p><asp:TextBox ID="txtIngrediente3" runat="server"></asp:TextBox></p>--%>
        <p>
            <asp:DropDownList ID="DropDownListIngrediente1" runat="server" DataTextField="Nome"
                DataValueField="Id">
            </asp:DropDownList>
        </p>
        <p>
            <asp:DropDownList ID="DropDownListIngrediente2" runat="server" DataTextField="Nome"
                DataValueField="Id">
            </asp:DropDownList>
        </p>
        <p>
            <asp:DropDownList ID="DropDownListIngrediente3" runat="server" DataTextField="Nome"
                DataValueField="Id">
            </asp:DropDownList>
        </p>
        <p>
            <input id="chkBordaRecheada" name="chkBordaRecheada" type="checkbox" />Borda Recheada?</p>
        <input id="ButtonAddPizza" type="button" value="Incluir Pizza" />
    </div>
    <br />
    <br />
    <div id="divIngrediente">
        <b>Novo Ingrediente:</b>
        <asp:TextBox ID="txtIngrediente" runat="server"></asp:TextBox>
        <p>
            <input id="ButtonAddIngrediente" type="button" value="Novo Ingrediente" /></p>
    </div>
    <div id="divResultado">
    </div>
    <script src="Scripts/jquery-1.6.4.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.noty.js" type="text/javascript"></script>
    <script src="Scripts/NotyAlert.js" type="text/javascript"></script>
    <script type="text/javascript">
        $("#ButtonAddPizza").click(function () {
            //checked
            //var checked = $('input[name=chkBordaRecheada]:checked').val();
            var checked = $('input[#chkBordaRecheada]:checked').val();
            var valueCheck = true;

            if (checked == undefined)
                valueCheck = false;

            var dados = {
                Nome: $("#txtNome").val(),
                Ingrediente1: $("#DropDownListIngrediente1").val(),
                Ingrediente2: $("#DropDownListIngrediente2").val(),
                Ingrediente3: $("#DropDownListIngrediente3").val(),
                Borda: valueCheck
            };
            
            if (dados.Nome != null && dados.Nome != "") {
                var request = $.ajax({
                    type: "POST",
                    url: "Default.aspx?insertNewPizza=1",
                    data: dados
                });

                request.done(function () {
                    NotyAlert("Pizza inserida com sucesso","success");
                    $("#txtNome").val("");

                });

                request.fail(function (jqXHR, textStatus) {
                    NotyAlert("Request failed: " + textStatus,"error");
                });
            }
            else {
                NotyAlert("Nome da pizza não preenchido","error");
            }
        });

        $("#ButtonAddIngrediente").click(function () {

            var dados = {
                Ingrediente: $("#txtIngrediente").val()

            };

            if (dados.Ingrediente != null && dados.Ingrediente != "") {
                var request = $.ajax({
                    type: "POST",
                    url: "Default.aspx?insertNewIngrediente=1",
                    data: dados

                });

                request.done(function () {
                    NotyAlert("Ingrediente inserido com sucesso","success");
                    CarregarIngredientes();
                    $("#txtIngrediente").val("");
                });

                request.fail(function (jqXHR, textStatus) {
                    NotyAlert("Request failed: " + textStatus,"error");
                });
            }
            else {
                NotyAlert("Ingrediente não preenchido", "error");
            }

        });

        function CarregarIngredientes() {
            var dados = {};
            var request = $.ajax({
                type: "POST",
                url: "Default.aspx/CarregaDropDownListAjax",
                data: dados,
                contentType: "application/json"
            });


            request.done(function (data) {
                $("#divResultado").html(data);
                $('#DropDownListIngrediente1').find("option").remove();
                $('#DropDownListIngrediente2').find("option").remove();
                $('#DropDownListIngrediente3').find("option").remove();
                $.each(data.d, function (index, ingrediente) {
                    $('#DropDownListIngrediente1').append("<option value='" + ingrediente.Id + "'>" + ingrediente.Nome + "</option>");
                    $('#DropDownListIngrediente2').append("<option value='" + ingrediente.Id + "'>" + ingrediente.Nome + "</option>");
                    $('#DropDownListIngrediente3').append("<option value='" + ingrediente.Id + "'>" + ingrediente.Nome + "</option>");
                });

            });

            request.fail(function (jqXHR, textStatus) {
                NotyAlert("Request failed: " + textStatus,"error");
            });
        }
        
        
        
    </script>
</asp:Content>
