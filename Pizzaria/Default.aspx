<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Pizzaria._Default" ClientIDMode="Static" ViewStateMode="Disabled"%>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Pizzaria!
    </h2>
    
    <div id="divPizza">
        <p>Nova Pizza</p>
        <p>
        <b>Nome da Pizza:</b>
            <input id="txtNome" type="text" />
        </p>
        <p>Ingredientes: </p>
        <%--<p><asp:TextBox ID="txtIngrediente1" runat="server"></asp:TextBox></p>
        <p><asp:TextBox ID="txtIngrediente2" runat="server"></asp:TextBox></p>    
        <p><asp:TextBox ID="txtIngrediente3" runat="server"></asp:TextBox></p>--%>
        <p><asp:DropDownList ID="DropDownListIngrediente1" runat="server" DataTextField="Nome" DataValueField="Id">
        </asp:DropDownList></p>
        <p><asp:DropDownList ID="DropDownListIngrediente2" runat="server" DataTextField="Nome" DataValueField="Id">
        </asp:DropDownList></p>
        <p><asp:DropDownList ID="DropDownListIngrediente3" runat="server" DataTextField="Nome" DataValueField="Id">
        </asp:DropDownList></p>
        <!--<asp:Button ID="btIncluir" runat="server" Text="Inclui com AJAX" />-->
        <input id="ButtonAddPizza" type="button" value="Incluir com AJAX" />
    </div>
    <br/><br/>
    <div id="divIngrediente">
    <b>Novo Ingrediente:</b>
    <asp:TextBox id="txtIngrediente" runat="server"></asp:TextBox>
        <p><input id="ButtonAddIngrediente" type="button" value="Novo Ingrediente"/></p>
    </div>
    
    <div id="divResultado"></div>
    <script src="Scripts/jquery-1.6.4.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.noty.js" type="text/javascript"></script>
    <script type="text/javascript">
        $("#ButtonAddPizza").click(function () {
            
            var dados = {
                Nome: $("#txtNome").val(),
                Ingrediente1: $("#DropDownListIngrediente1").val(),
                Ingrediente2: $("#DropDownListIngrediente2").val(),
                Ingrediente3: $("#DropDownListIngrediente3").val()

            };
            var request = $.ajax({
                type: "POST",
                url: "Default.aspx?insertNewPizza=1",
                data: dados
            });

            request.done(function () {
                noty({ "text": "Pizza inserida com sucesso", "layout": "center", "type": "sucess", "textAlign": "center", "easing": "swing", "animateOpen": { "height": "toggle" }, "animateClose": { "height": "toggle" }, "speed": "500", "timeout": "5000", "closable": true, "closeOnSelfClick": true });
                
            });

            request.fail(function (jqXHR, textStatus) {
                alert("Request failed: " + textStatus);
            });
        });

        $("#ButtonAddIngrediente").click(function () {

            var dados = {
                Ingrediente: $("#txtIngrediente").val()
                
            };
            var request = $.ajax({
                type: "POST",
                url: "Default.aspx?insertNewIngrediente=1",
                data: dados
            });

            request.done(function () {
                noty({ "text": "Ingrediente inserido com sucesso", "layout": "center", "type": "success", "textAlign": "center", "easing": "swing", "animateOpen": { "height": "toggle" }, "animateClose": { "height": "toggle" }, "speed": "500", "timeout": "5000", "closable": true, "closeOnSelfClick": true });
            });

            request.fail(function (jqXHR, textStatus) {
                alert("Request failed: " + textStatus);
            });
        });

        function PesquisarIngredientes() {
            var dados = {
                Ingrediente: $("#txtIngrediente").val()

            };
            var request = $.ajax({
                type: "POST",
                url: "Default.aspx?insertNewIngrediente=1",
                data: dados,
                dataType: "json",
                contentType: "application/json; charset=utf-8"
            });

            request.done(function (data) {
                $("#divResultado").html(data);
            });

            request.fail(function (jqXHR, textStatus) {
                alert("Request failed: " + textStatus);
            });
        }
    </script>
</asp:Content>
