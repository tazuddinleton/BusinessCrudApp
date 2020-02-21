"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var UtilityService = /** @class */ (function () {
    function UtilityService() {
    }
    UtilityService.prototype.strToHash = function (str) {
        var hash = 0, i, chr;
        if (str.length === 0)
            return hash;
        for (i = 0; i < str.length; i++) {
            chr = str.charCodeAt(i);
            hash = ((hash << 5) - hash) + chr;
            hash |= 0; // Convert to 32bit integer
        }
        return hash;
    };
    UtilityService.prototype.getFilenameExt = function (filename) {
        return filename.slice((filename.lastIndexOf(".") - 1 >>> 0) + 2);
    };
    UtilityService.prototype.hashifyFilename = function (filename) {
        return this.strToHash(filename) + '.' + this.getFilenameExt(filename);
    };
    return UtilityService;
}());
exports.UtilityService = UtilityService;
//# sourceMappingURL=utilityService.js.map