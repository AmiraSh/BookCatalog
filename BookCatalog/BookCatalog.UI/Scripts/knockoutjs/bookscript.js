var BookModel = BookModel || {};

(function () {
    var self = this;

    self.DataTableId = '#booksTable';
    self.DataTable;
    self.IsEdited = false;
    self.BooksList;

    self.Initialize = function (data) {
        self.BooksList = {
            Books: ko.observableArray()
        };

        $(data).each(function (index, element) {
            var mappedItem =
                {
                    Id: ko.observable(element.Id),
                    Name: ko.observable(element.Name),
                    PublishedDate: ko.observable(element.PublishedDate),
                    PagesCount: ko.observable(element.PagesCount),
                    Rating: ko.observable(element.Rating),
                    Authors: ko.observable(element.Authors)
                };
            self.BooksList.Books.push(mappedItem);
        });
        ko.applyBindings(self.BooksList);
        self.InitBookDataTable();
    }

    self.InitBookDataTable = function () {
        self.DataTable = $(self.DataTableId).dataTable({
            "aoColumns": [
                { "sClass": "Id", "mDataProp": "Id" },
                { "sClass": "Name", "mDataProp": "Name" },
                { "sClass": "PublishedDate", "mDataProp": "PublishedDate" },
                { "sClass": "PagesCount", "mDataProp": "PagesCount" },
                { "sClass": "Rating", "mDataProp": "Rating" },
                { "sClass": "Authors", "mDataProp": "Authors" },
                { "sClass": "Controls", "mDataProp": "Controls" }
            ]
        });
    }
}).apply(BookModel);