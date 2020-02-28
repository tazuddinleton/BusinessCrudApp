"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var Syllabus = /** @class */ (function () {
    function Syllabus(id, name, tradeId, tradeLevelId, devOfficer, manager, languages, activeDate) {
        this.id = id;
        this.name = name;
        this.tradeId = tradeId;
        this.tradeLevelId = tradeLevelId;
        this.developmentOfficer = devOfficer;
        this.manager = manager;
        this.languages = languages;
        this.activeDate = activeDate != '' ? new Date(activeDate) : null;
    }
    Syllabus.prototype.setTradeName = function (tradeName) {
        this.tradeName = tradeName;
    };
    Syllabus.prototype.setTradeLevelName = function (tradeLevelName) {
        this.tradeLevelName = tradeLevelName;
    };
    return Syllabus;
}());
exports.Syllabus = Syllabus;
//# sourceMappingURL=syllabus.model.js.map