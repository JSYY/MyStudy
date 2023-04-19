const HtmlWebpackPlugin = require("html-webpack-plugin");
const { VueLoaderPlugin }  = require("vue-loader");
const { CleanWebpackPlugin } = require('clean-webpack-plugin');
const { DefinePlugin } = require('webpack');
const CssMinimizerPlugin = require("css-minimizer-webpack-plugin");

module.exports = {
    mode: "development",
    optimization: {
        minimizer: [
            '...',
            new CssMinimizerPlugin(),
        ],
    },
    entry: "./src/main.ts",
    module: {
        rules: [
            {
                test: /\.vue$/,
                use: "vue-loader",
            },
            {
                test: /\.(t|j)s$/,
                exclude: /node_modules/,
                use: {
                    loader: "babel-loader",
                    options: {
                        cacheDirectory: true,
                    },
                },
            },
            {
                test: /\.(sa|sc|c)ss$/,
                use: ["style-loader", "css-loader", "sass-loader"],
            },
            {
                test: /\.(png|svg|jpe?g|gif)$/,
                type: "asset",
                generator: {
                    filename: "images/[name]-[hash][ext]",
                },
            },
        ],
    },
    plugins: [
        new HtmlWebpackPlugin({
            title: "webpackTest",
            template: "./index.html",
            minify: {
                collapseWhitespace: true, // ȥ���ո�
                removeComments: true // ȥ��ע��
            }
        }),
        new VueLoaderPlugin(),
        new CleanWebpackPlugin(),
        new DefinePlugin({
                '__VUE_OPTIONS_API__': true,//��������ϵ�vue����
                 '__VUE_PROD_DEVTOOLS__': false
        }),
    ],
    target: "web",
    devServer: {
        hot: true, // ������ģ���滻
        open: true, // ��Ĭ�������
    },
    //devServer: {
    //    proxy: {
    //        "/api": {
    //            // ��Ҫ��������ʵĿ�����������/api/user�ᱻ����https://www.juejin.cn/api/user
    //            target: "https://www.juejin.cn",
    //            // �Ƿ���Ĵ���������headers��host��ַ��ĳЩ��ȫ����ϸߵķ�������Դ���У��
    //            changeOrigin: true,
    //            // Ĭ������²����ܽ�����ת����https��api�������ϣ����ϣ��֧�֣���������Ϊfalse
    //            secure: false,
    //            // Ĭ�������/apiҲ��д�뵽����url�У�ͨ��������ÿ��Խ���ɾ��
    //            pathRewrite: {
    //                "^/api": "/",
    //            },
    //        },
    //    },
    //},
};