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
                collapseWhitespace: true, // 去掉空格
                removeComments: true // 去掉注释
            }
        }),
        new VueLoaderPlugin(),
        new CleanWebpackPlugin(),
        new DefinePlugin({
                '__VUE_OPTIONS_API__': true,//清除界面上的vue警告
                 '__VUE_PROD_DEVTOOLS__': false
        }),
    ],
    target: "web",
    devServer: {
        hot: true, // 启用热模块替换
        open: true, // 打开默认浏览器
    },
    //devServer: {
    //    proxy: {
    //        "/api": {
    //            // 需要代理到的真实目标服务器，如/api/user会被代理到https://www.juejin.cn/api/user
    //            target: "https://www.juejin.cn",
    //            // 是否更改代理后请求的headers中host地址，某些安全级别较高的服务器会对此做校验
    //            changeOrigin: true,
    //            // 默认情况下不接受将请求转发到https的api服务器上，如果希望支持，可以设置为false
    //            secure: false,
    //            // 默认情况下/api也会写入到请求url中，通过这个配置可以将其删除
    //            pathRewrite: {
    //                "^/api": "/",
    //            },
    //        },
    //    },
    //},
};