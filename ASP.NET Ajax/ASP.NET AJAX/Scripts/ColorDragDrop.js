Type.registerNamespace('Custom.UI');

///////////////////////////////////////////////////////////////////////
// ColorDragSourceBehavior class

Custom.UI.ColorDragSourceBehavior = function(element, color)
{
    Custom.UI.ColorDragSourceBehavior.initializeBase(this, [element]);
    this._mouseDownHandler = Function.createDelegate(this, this.mouseDownHandler);
    this._color = color;
    this._visual = null;
}

Custom.UI.ColorDragSourceBehavior.prototype =
{
    // IDragSource methods
    get_dragDataType: function()
    {
        return 'DragDropColor';
    },

    getDragData: function(context)
    {
        return this._color;
    },

    get_dragMode: function()
    {
        return Sys.Preview.UI.DragMode.Copy;
    },

    onDragStart: function()
    {
    },

    onDrag: function()
    {
    },

    onDragEnd: function(canceled)
    {
        if (this._visual)
            this.get_element().parentNode.removeChild(this._visual);
    },
    
    // Other methods
    initialize: function()
    {
        Custom.UI.ColorDragSourceBehavior.callBaseMethod(this, 'initialize');
        $addHandler(this.get_element(), 'mousedown', this._mouseDownHandler)
    },

    mouseDownHandler: function(ev)
    {
        window._event = ev; // Needed internally by _DragDropManager

        this._visual = this.get_element().cloneNode(true);
        this._visual.style.opacity = '0.4';
        this._visual.style.filter = 'progid:DXImageTransform.Microsoft.BasicImage(opacity=0.4)';
        this._visual.style.zIndex = 99999;
        this.get_element().parentNode.appendChild(this._visual);
        var location = Sys.UI.DomElement.getLocation(this.get_element());
        Sys.UI.DomElement.setLocation(this._visual, location.x, location.y);

        Sys.Preview.UI.DragDropManager.startDragDrop(this, this._visual, null);
    },

    dispose: function()
    {
        if (this._mouseDownHandler)
            $removeHandler(this.get_element(), 'mousedown', this._mouseDownHandler);
        this._mouseDownHandler = null;
        Custom.UI.ColorDragSourceBehavior.callBaseMethod(this, 'dispose');
    }
}

Custom.UI.ColorDragSourceBehavior.registerClass('Custom.UI.ColorDragSourceBehavior',
    Sys.UI.Behavior, Sys.Preview.UI.IDragSource);

///////////////////////////////////////////////////////////////////////
// ColorDropTargetBehavior class

Custom.UI.ColorDropTargetBehavior = function(element)
{
    Custom.UI.ColorDropTargetBehavior.initializeBase(this, [element]);
    this._color = null;
}
    
Custom.UI.ColorDropTargetBehavior.prototype =
{
    // IDropTarget methods
    get_dropTargetElement: function()
    {
        return this.get_element();
    },

    canDrop: function(dragMode, dataType, data)
    {
        return (dataType == 'DragDropColor' && data);
    },

    drop : function(dragMode, dataType, data)
    {
        if (dataType == 'DragDropColor' && data)
        {
            this.get_element().style.backgroundColor = data;
        }
    },

    onDragEnterTarget : function(dragMode, dataType, data)
    {
        if (dataType == 'DragDropColor' && data)
        {
            this._color = this.get_element().style.backgroundColor;
            this.get_element().style.backgroundColor = '#E0E0E0';
        }
    },
    
    onDragLeaveTarget : function(dragMode, dataType, data)
    {
        if (dataType == 'DragDropColor' && data)
        {
            this.get_element().style.backgroundColor = this._color;
        }
    },

    onDragInTarget : function(dragMode, dataType, data)
    {
    },
    
    // Other methods
    initialize: function()
    {
        Custom.UI.ColorDropTargetBehavior.callBaseMethod(this, 'initialize');
        Sys.Preview.UI.DragDropManager.registerDropTarget(this);
    },
    
    dispose: function()
    {
        Sys.Preview.UI.DragDropManager.unregisterDropTarget(this);
        Custom.UI.ColorDropTargetBehavior.callBaseMethod(this, 'dispose');
    }
}

Custom.UI.ColorDropTargetBehavior.registerClass('Custom.UI.ColorDropTargetBehavior',
    Sys.UI.Behavior, Sys.Preview.UI.IDropTarget);

///////////////////////////////////////////////////////////////////////
// Script registration

Sys.Application.notifyScriptLoaded();
