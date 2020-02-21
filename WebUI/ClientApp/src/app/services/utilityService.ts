export class UtilityService {
    constructor() { }

    strToHash(str: string) {
        var hash = 0, i, chr;

        if (str.length === 0) return hash;
        for (i = 0; i < str.length; i++) {
            chr = str.charCodeAt(i);
            hash = ((hash << 5) - hash) + chr;
            hash |= 0; // Convert to 32bit integer
        }
        return hash;
    }


    getFilenameExt(filename: string) {
        return filename.slice((filename.lastIndexOf(".") - 1 >>> 0) + 2);
    }

    hashifyFilename(filename: string): string {
        return this.strToHash(filename) + '.' + this.getFilenameExt(filename);
    }
}
