const path = require('path');
const { VueLoaderPlugin } = require('vue-loader');
const { CleanWebpackPlugin } = require('clean-webpack-plugin');

module.exports = {
    entry: './src/main.js',
    output: {
        path: path.resolve(__dirname,'dist'),
        filename: 'bundle.js',

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
            },
            {
                // ����ͼƬ��Դ
                test: /\.(jpg|png|gif)$/,
                // webpack5��ʹ��assets-module��url-loader�ѷ�����
                type: 'asset',
                parser: {
                    dataUrlCondition: {
                        maxSize: 10 * 1024
                    }
                },
                generator: {
                    filename: 'img/[name].[hash:6][ext]',
                }
            }
        ],
    },
    plugins: [
        new VueLoaderPlugin(),
        new CleanWebpackPlugin(),
    ],
}