"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.compressImage = void 0;
const sharp_1 = __importDefault(require("sharp"));
async function compressImage(input, options = {}) {
    const { maxWidth = 1024, maxHeight = 1024, quality = 80, format = { id: 'jpeg' } } = options;
    const transformer = (0, sharp_1.default)()
        .resize({ width: maxWidth, height: maxHeight, fit: 'inside', withoutEnlargement: true })
        .toFormat(format, { quality });
    if (Buffer.isBuffer(input)) {
        return transformer.toBuffer();
    }
    else {
        return input.pipe(transformer).toBuffer();
    }
}
exports.compressImage = compressImage;
