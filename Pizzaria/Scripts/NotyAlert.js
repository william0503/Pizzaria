function NotyAlert(txt, tipo) {
    noty({ "text": txt, "layout": "center", "type": tipo, "textAlign": "center", "easing": "swing", "animateOpen": { "height": "toggle" }, "animateClose": { "height": "toggle" }, "speed": "500", "timeout": "5000", "closable": true, "closeOnSelfClick": true });
}