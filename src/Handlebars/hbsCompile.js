var hbs = require('handlebars');
var fs = require("fs");

module.exports = function (callback, viewPath, model, viewDictionary, modelState) {
    // Invoke some external transpiler (e.g., an NPM module) then:
    fs.readFile(viewPath, (err, data) => {
        if (err) { throw err;}
        var template = hbs.compile(data);
        model = model || {};
        model.ViewData = viewDictionary;
        model.ModelState = modelState;
        callback(null, template(model));
    });

};