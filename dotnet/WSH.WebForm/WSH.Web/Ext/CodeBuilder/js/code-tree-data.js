code.tree = {
    data:
        { text: "CodeType", expanded: true, children: [
            { text: "Entity", expanded: true, children: [
                { text: "Entity", leaf: true, id: "entity-e" }
            ]
            },
            { text: "AspNet", leaf: false, expanded: true, children: [
                { text: "GridView", leaf: true, id: "aspnet-gv" },
                { text: "Form", leaf: true, id: "aspnet-form" },
                { text: "MvcGrid", leaf: true, id: "aspnet-mvc-grid" },
                {text:"MvcController",leaf:true,id:"aspnet-mvc-controller"}
            ]
            },
            { text: "WinForm", leaf: false, expanded: true, children: [
                { text: "DataGridViewColumns", leaf: true, id: "winform-dgvc" }
            ]
            },
            { text: "Ext", expanded: true, children: [
                { text: "Grid", leaf: true, id: "ext-g" },
                { text: "EditGrid", leaf: true, id: "ext-eg" }
            ]
            },
            { text: "JavaScript", expanded: true, children: [
                { text: "GT-Grid", leaf: true, id: "js-gtg" },
                { text: "FlexGrid", leaf: true, id: "js-fg" }
            ]
            }
        ]
        }
}