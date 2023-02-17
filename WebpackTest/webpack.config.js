const path = require('path');
const { VueLoaderPlugin } = require('vue-loader');
module.exports = {
    entry: './src/main.js',
    output: {
        path: path.resolve(__dirname,'dist'),
        filename:'bundle.js',
    },
    module: {
        rules: [
            { test: /\.vue$/, use: 'vue-loader' },
            {
                test: /\.css$/, use: [
                    {
                        loader:'vue-style-loader'
                    },
                    {
                        loader:'css-loader'
                    }
                ]
            }
        ],
    },
    plugins: [
        new VueLoaderPlugin(),
    ],
}