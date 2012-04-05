// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/resources/sharedsource/licensingbasics/sharedsourcelicenses.mspx.
// All other rights reserved.


// README
//
// There are two steps to adding a property:
//
// 1. Create a member variable to store your property
// 2. Add the get_ and set_ accessors for your property.
//
// Remember that both are case sensitive!
//

Type.registerNamespace('DropDownListWatermark');

DropDownListWatermark.DropDownListWatermarkBehavior = function(element) {

    DropDownListWatermark.DropDownListWatermarkBehavior.initializeBase(this, [element]);

    this._watermarkText = null;
    this._changeHandler = null;
}

DropDownListWatermark.DropDownListWatermarkBehavior.prototype = {

    //
    // Initialize
    //
    initialize : function() {
        DropDownListWatermark.DropDownListWatermarkBehavior.callBaseMethod(this, 'initialize');

        var clientState = DropDownListWatermark.DropDownListWatermarkBehavior.callBaseMethod(this, 'get_ClientState');

        if (clientState != '__postback__')
        {
            var e = this.get_element();

            // Register event handler
            this._changeHandler = Function.createDelegate(this, this._onChange);
            $addHandler(e, 'change', this._changeHandler);

            // Add watermark to drop-down list
            this._addWatermark();
        }
    },

    //
    // Dispose
    //
    dispose : function() {
        var e = this.get_element();

        // Deregister event handler
        if (this._changeHandler)
        {
            $removeHandler(e, 'change', this._changeHandler);
            this._changeHandler = null;
        }

        DropDownListWatermark.DropDownListWatermarkBehavior.callBaseMethod(this, 'dispose');
    },

    //
    // Event handlers
    //
    _onChange : function()
    {
        this._removeWatermark();
    },

    _onSubmit : function()
    {
        this._removeWatermark();
    },

    //
    // Helper functions
    //
    _addWatermark : function()
    {
        var e = this.get_element();

        if (e.options[0].value != '__watermark__')
        {
            e.options[e.options.length] = new Option(this._watermarkText, '__watermark__');
            e.insertBefore(e.options[e.options.length-1], e.options[0]);
            e.options[0].selected = true;
        }
    },
    
    _removeWatermark : function()
    {
        var e = this.get_element();

        if (e.options[0].value == '__watermark__')
            e.options.remove(0);
    },

    //
    // Properties
    //
    get_WatermarkText : function()
    {
        return this._watermarkText;
    },

    set_WatermarkText : function(value)
    {
        this._watermarkText = value;
    }
}

DropDownListWatermark.DropDownListWatermarkBehavior.registerClass('DropDownListWatermark.DropDownListWatermarkBehavior', AjaxControlToolkit.BehaviorBase);