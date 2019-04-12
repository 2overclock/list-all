"use strict";

const path = require('path');
const bundleFileName = 'bundle';

module.exports = {
    mode: "development",
    entry: ['./src/index.js', './src/sass/index.scss'],
    output: {
        filename: bundleFileName + '.js',
        path: path.resolve(__dirname, 'wwwroot/dist')
    },
    module: {
        rules: [{
            test: /\.scss$/,
            use: [
                {
                    loader: 'file-loader',
                    options: {
                        name: bundleFileName + '.css'
                    }
                },
                {
                    loader: 'extract-loader'
                },
                {
                    loader: "css-loader",
                    options: {
                        //minimize: true || {/* or CSSNano Options */ }
                    }
                },
                {
                    loader: "sass-loader"
                }
            ]
        }]
    }
};