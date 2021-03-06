﻿angular.module('ofgMobile')
    .factory('LocalDBService', [
        function () {
            var service = {};
            service.db = {};

            service.openDB = function (name) {
                service.db = new loki(name, { autosave: true, autosaveInterval: 1000 });
            };

            service.getCollection = function (name) {
                if (service.db != null) {
                    var collection = db.getCollection(name);

                    if (collection == null) {
                        collection = db.addCollection(name);
                    }

                    return collection;
                }

                return null;
            };

            service.addItem = function (collectionName, item) {
                var collection = service.getCollection(collectionName);
                if (collection != null) {
                    return collection.insert(item);
                }

                return null;
            };

            service.updateItem = function (collectionName, item) {
                var collection = service.getCollection(collectionName);
                if (collection != null) {
                    return collection.update(item);
                }

                return null;
            };

            service.persistItem = function(collectionName, item) {
                if (item.id == null) {
                    return service.addItem(collectionName, item);
                } else {
                    return service.updateItem(collectionName, item);
                }
            };

            service.getItem = function (collectionName, itemId) {
                var collection = service.getCollection(collectionName);
                if (collection != null) {
                    return collection.get(itemId);
                }

                return null;
            };

            service.deleteItem = function(collectionName, itemId) {
                var collection = service.getCollection(collectionName);
                if (collection != null) {
                    collection.remove(itemId);
                }
            };

            service.findItems = function (collectionName, query) {
                var collection = service.getCollection(collectionName);
                if (collection != null) {
                    return collection.find(query);
                }

                return null;
            };

            service.openDB('localdata.db');

            return service;
        }
    ]);
