(function webpackUniversalModuleDefinition(root, factory) {
	if(typeof exports === 'object' && typeof module === 'object')
		module.exports = factory();
	else if(typeof define === 'function' && define.amd)
		define([], factory);
	else if(typeof exports === 'object')
		exports["my-component"] = factory();
	else
		root["my-component"] = factory();
})((typeof self !== 'undefined' ? self : this), function() {
return /******/ (function() { // webpackBootstrap
/******/ 	var __webpack_modules__ = ({

/***/ "./node_modules/@vue/cli-service/lib/commands/build/setPublicPath.js":
/*!***************************************************************************!*\
  !*** ./node_modules/@vue/cli-service/lib/commands/build/setPublicPath.js ***!
  \***************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* eslint-disable no-var */
// This file is imported into lib/wc client bundles.

if (typeof window !== 'undefined') {
  var currentScript = window.document.currentScript
  if (false) { var getCurrentScript; }

  var src = currentScript && currentScript.src.match(/(.+\/)[^/]+\.js(\?.*)?$/)
  if (src) {
    __webpack_require__.p = src[1] // eslint-disable-line
  }
}

// Indicate to webpack that this file can be concatenated
/* harmony default export */ __webpack_exports__["default"] = (null);


/***/ }),

/***/ "./node_modules/css-loader/dist/cjs.js??clonedRuleSet-77.use[1]!./node_modules/vue-loader/dist/stylePostLoader.js!./node_modules/postcss-loader/dist/cjs.js??clonedRuleSet-77.use[2]!./node_modules/postcss-loader/dist/cjs.js??clonedRuleSet-77.use[3]!./node_modules/less-loader/dist/cjs.js??clonedRuleSet-77.use[4]!./node_modules/vue-loader/dist/index.js??ruleSet[0].use[0]!./src/components/MyButton/Button.vue?vue&type=style&index=0&id=c6c550e8&scoped=true&lang=less":
/*!***************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************!*\
  !*** ./node_modules/css-loader/dist/cjs.js??clonedRuleSet-77.use[1]!./node_modules/vue-loader/dist/stylePostLoader.js!./node_modules/postcss-loader/dist/cjs.js??clonedRuleSet-77.use[2]!./node_modules/postcss-loader/dist/cjs.js??clonedRuleSet-77.use[3]!./node_modules/less-loader/dist/cjs.js??clonedRuleSet-77.use[4]!./node_modules/vue-loader/dist/index.js??ruleSet[0].use[0]!./src/components/MyButton/Button.vue?vue&type=style&index=0&id=c6c550e8&scoped=true&lang=less ***!
  \***************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************/
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _node_modules_css_loader_dist_runtime_noSourceMaps_js__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../../../node_modules/css-loader/dist/runtime/noSourceMaps.js */ "./node_modules/css-loader/dist/runtime/noSourceMaps.js");
/* harmony import */ var _node_modules_css_loader_dist_runtime_noSourceMaps_js__WEBPACK_IMPORTED_MODULE_0___default = /*#__PURE__*/__webpack_require__.n(_node_modules_css_loader_dist_runtime_noSourceMaps_js__WEBPACK_IMPORTED_MODULE_0__);
/* harmony import */ var _node_modules_css_loader_dist_runtime_api_js__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ../../../node_modules/css-loader/dist/runtime/api.js */ "./node_modules/css-loader/dist/runtime/api.js");
/* harmony import */ var _node_modules_css_loader_dist_runtime_api_js__WEBPACK_IMPORTED_MODULE_1___default = /*#__PURE__*/__webpack_require__.n(_node_modules_css_loader_dist_runtime_api_js__WEBPACK_IMPORTED_MODULE_1__);
// Imports


var ___CSS_LOADER_EXPORT___ = _node_modules_css_loader_dist_runtime_api_js__WEBPACK_IMPORTED_MODULE_1___default()((_node_modules_css_loader_dist_runtime_noSourceMaps_js__WEBPACK_IMPORTED_MODULE_0___default()));
// Module
___CSS_LOADER_EXPORT___.push([module.id, ".mybutton[data-v-c6c550e8]{width:100px;height:30px}", ""]);
// Exports
/* harmony default export */ __webpack_exports__["default"] = (___CSS_LOADER_EXPORT___);


/***/ }),

/***/ "./node_modules/css-loader/dist/runtime/api.js":
/*!*****************************************************!*\
  !*** ./node_modules/css-loader/dist/runtime/api.js ***!
  \*****************************************************/
/***/ (function(module) {

"use strict";


/*
  MIT License http://www.opensource.org/licenses/mit-license.php
  Author Tobias Koppers @sokra
*/
module.exports = function (cssWithMappingToString) {
  var list = [];

  // return the list of modules as css string
  list.toString = function toString() {
    return this.map(function (item) {
      var content = "";
      var needLayer = typeof item[5] !== "undefined";
      if (item[4]) {
        content += "@supports (".concat(item[4], ") {");
      }
      if (item[2]) {
        content += "@media ".concat(item[2], " {");
      }
      if (needLayer) {
        content += "@layer".concat(item[5].length > 0 ? " ".concat(item[5]) : "", " {");
      }
      content += cssWithMappingToString(item);
      if (needLayer) {
        content += "}";
      }
      if (item[2]) {
        content += "}";
      }
      if (item[4]) {
        content += "}";
      }
      return content;
    }).join("");
  };

  // import a list of modules into the list
  list.i = function i(modules, media, dedupe, supports, layer) {
    if (typeof modules === "string") {
      modules = [[null, modules, undefined]];
    }
    var alreadyImportedModules = {};
    if (dedupe) {
      for (var k = 0; k < this.length; k++) {
        var id = this[k][0];
        if (id != null) {
          alreadyImportedModules[id] = true;
        }
      }
    }
    for (var _k = 0; _k < modules.length; _k++) {
      var item = [].concat(modules[_k]);
      if (dedupe && alreadyImportedModules[item[0]]) {
        continue;
      }
      if (typeof layer !== "undefined") {
        if (typeof item[5] === "undefined") {
          item[5] = layer;
        } else {
          item[1] = "@layer".concat(item[5].length > 0 ? " ".concat(item[5]) : "", " {").concat(item[1], "}");
          item[5] = layer;
        }
      }
      if (media) {
        if (!item[2]) {
          item[2] = media;
        } else {
          item[1] = "@media ".concat(item[2], " {").concat(item[1], "}");
          item[2] = media;
        }
      }
      if (supports) {
        if (!item[4]) {
          item[4] = "".concat(supports);
        } else {
          item[1] = "@supports (".concat(item[4], ") {").concat(item[1], "}");
          item[4] = supports;
        }
      }
      list.push(item);
    }
  };
  return list;
};

/***/ }),

/***/ "./node_modules/css-loader/dist/runtime/noSourceMaps.js":
/*!**************************************************************!*\
  !*** ./node_modules/css-loader/dist/runtime/noSourceMaps.js ***!
  \**************************************************************/
/***/ (function(module) {

"use strict";


module.exports = function (i) {
  return i[1];
};

/***/ }),

/***/ "./node_modules/thread-loader/dist/cjs.js!./node_modules/babel-loader/lib/index.js!./node_modules/ts-loader/index.js??clonedRuleSet-86.use[2]!./node_modules/vue-loader/dist/index.js??ruleSet[0].use[0]!./src/components/MyButton/Button.vue?vue&type=script&lang=ts":
/*!****************************************************************************************************************************************************************************************************************************************************************************!*\
  !*** ./node_modules/thread-loader/dist/cjs.js!./node_modules/babel-loader/lib/index.js!./node_modules/ts-loader/index.js??clonedRuleSet-86.use[2]!./node_modules/vue-loader/dist/index.js??ruleSet[0].use[0]!./src/components/MyButton/Button.vue?vue&type=script&lang=ts ***!
  \****************************************************************************************************************************************************************************************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var vue__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! vue */ "vue");
/* harmony import */ var vue__WEBPACK_IMPORTED_MODULE_0___default = /*#__PURE__*/__webpack_require__.n(vue__WEBPACK_IMPORTED_MODULE_0__);

/* harmony default export */ __webpack_exports__["default"] = ((0,vue__WEBPACK_IMPORTED_MODULE_0__.defineComponent)({
  name: 'MyButton',
  props: {
    name: String
  },
  setup(props) {
    (0,vue__WEBPACK_IMPORTED_MODULE_0__.onMounted)(() => {
      console.log(props.name);
      console.log("button init");
    });
  }
}));

/***/ }),

/***/ "./node_modules/thread-loader/dist/cjs.js!./node_modules/babel-loader/lib/index.js!./node_modules/ts-loader/index.js??clonedRuleSet-86.use[2]!./node_modules/vue-loader/dist/templateLoader.js??ruleSet[1].rules[4]!./node_modules/vue-loader/dist/index.js??ruleSet[0].use[0]!./src/components/MyButton/Button.vue?vue&type=template&id=c6c550e8&scoped=true&ts=true":
/*!****************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************!*\
  !*** ./node_modules/thread-loader/dist/cjs.js!./node_modules/babel-loader/lib/index.js!./node_modules/ts-loader/index.js??clonedRuleSet-86.use[2]!./node_modules/vue-loader/dist/templateLoader.js??ruleSet[1].rules[4]!./node_modules/vue-loader/dist/index.js??ruleSet[0].use[0]!./src/components/MyButton/Button.vue?vue&type=template&id=c6c550e8&scoped=true&ts=true ***!
  \****************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "render": function() { return /* binding */ render; }
/* harmony export */ });
/* harmony import */ var vue__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! vue */ "vue");
/* harmony import */ var vue__WEBPACK_IMPORTED_MODULE_0___default = /*#__PURE__*/__webpack_require__.n(vue__WEBPACK_IMPORTED_MODULE_0__);

const _withScopeId = n => ((0,vue__WEBPACK_IMPORTED_MODULE_0__.pushScopeId)("data-v-c6c550e8"), n = n(), (0,vue__WEBPACK_IMPORTED_MODULE_0__.popScopeId)(), n);
const _hoisted_1 = {
  class: "mybutton"
};
function render(_ctx, _cache, $props, $setup, $data, $options) {
  return (0,vue__WEBPACK_IMPORTED_MODULE_0__.openBlock)(), (0,vue__WEBPACK_IMPORTED_MODULE_0__.createElementBlock)("button", _hoisted_1, (0,vue__WEBPACK_IMPORTED_MODULE_0__.toDisplayString)(_ctx.name), 1);
}

/***/ }),

/***/ "./src/components/MyButton/index.ts":
/*!******************************************!*\
  !*** ./src/components/MyButton/index.ts ***!
  \******************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _withInstall__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../../withInstall */ "./src/withInstall.ts");
/* harmony import */ var _Button_vue__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./Button.vue */ "./src/components/MyButton/Button.vue");


/* harmony default export */ __webpack_exports__["default"] = ((0,_withInstall__WEBPACK_IMPORTED_MODULE_0__.withInstall)(_Button_vue__WEBPACK_IMPORTED_MODULE_1__["default"]));

/***/ }),

/***/ "./src/index.ts":
/*!**********************!*\
  !*** ./src/index.ts ***!
  \**********************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "MyButton": function() { return /* reexport safe */ _src_components_MyButton__WEBPACK_IMPORTED_MODULE_0__["default"]; },
/* harmony export */   "getName": function() { return /* reexport safe */ _withInstall__WEBPACK_IMPORTED_MODULE_1__.getName; },
/* harmony export */   "install": function() { return /* binding */ install; },
/* harmony export */   "withInstall": function() { return /* reexport safe */ _withInstall__WEBPACK_IMPORTED_MODULE_1__.withInstall; }
/* harmony export */ });
/* harmony import */ var _src_components_MyButton__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ../src/components/MyButton */ "./src/components/MyButton/index.ts");
/* harmony import */ var _withInstall__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./withInstall */ "./src/withInstall.ts");

const components = [_src_components_MyButton__WEBPACK_IMPORTED_MODULE_0__["default"]];
const install = function (app) {
  components.forEach(component => {
    app.use(component);
  });
  return app;
};



/***/ }),

/***/ "./src/withInstall.ts":
/*!****************************!*\
  !*** ./src/withInstall.ts ***!
  \****************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "getName": function() { return /* binding */ getName; },
/* harmony export */   "withInstall": function() { return /* binding */ withInstall; }
/* harmony export */ });
const getName = comp => {
  const c = comp;
  return c.name;
};
const withInstall = comp => {
  const c = comp;
  c.install = function (app) {
    const name = getName(c);
    app.component(name, comp);
  };
  return comp;
};

/***/ }),

/***/ "./node_modules/vue-loader/dist/exportHelper.js":
/*!******************************************************!*\
  !*** ./node_modules/vue-loader/dist/exportHelper.js ***!
  \******************************************************/
/***/ (function(__unused_webpack_module, exports) {

"use strict";

Object.defineProperty(exports, "__esModule", ({ value: true }));
// runtime helper for setting properties on components
// in a tree-shakable way
exports["default"] = (sfc, props) => {
    const target = sfc.__vccOpts || sfc;
    for (const [key, val] of props) {
        target[key] = val;
    }
    return target;
};


/***/ }),

/***/ "./src/components/MyButton/Button.vue":
/*!********************************************!*\
  !*** ./src/components/MyButton/Button.vue ***!
  \********************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _Button_vue_vue_type_template_id_c6c550e8_scoped_true_ts_true__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./Button.vue?vue&type=template&id=c6c550e8&scoped=true&ts=true */ "./src/components/MyButton/Button.vue?vue&type=template&id=c6c550e8&scoped=true&ts=true");
/* harmony import */ var _Button_vue_vue_type_script_lang_ts__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./Button.vue?vue&type=script&lang=ts */ "./src/components/MyButton/Button.vue?vue&type=script&lang=ts");
/* harmony import */ var _Button_vue_vue_type_style_index_0_id_c6c550e8_scoped_true_lang_less__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! ./Button.vue?vue&type=style&index=0&id=c6c550e8&scoped=true&lang=less */ "./src/components/MyButton/Button.vue?vue&type=style&index=0&id=c6c550e8&scoped=true&lang=less");
/* harmony import */ var E_Git_MyStudy_vue_component_node_modules_vue_loader_dist_exportHelper_js__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! ./node_modules/vue-loader/dist/exportHelper.js */ "./node_modules/vue-loader/dist/exportHelper.js");




;


const __exports__ = /*#__PURE__*/(0,E_Git_MyStudy_vue_component_node_modules_vue_loader_dist_exportHelper_js__WEBPACK_IMPORTED_MODULE_3__["default"])(_Button_vue_vue_type_script_lang_ts__WEBPACK_IMPORTED_MODULE_1__["default"], [['render',_Button_vue_vue_type_template_id_c6c550e8_scoped_true_ts_true__WEBPACK_IMPORTED_MODULE_0__.render],['__scopeId',"data-v-c6c550e8"]])

/* harmony default export */ __webpack_exports__["default"] = (__exports__);

/***/ }),

/***/ "./src/components/MyButton/Button.vue?vue&type=script&lang=ts":
/*!********************************************************************!*\
  !*** ./src/components/MyButton/Button.vue?vue&type=script&lang=ts ***!
  \********************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "default": function() { return /* reexport safe */ _node_modules_thread_loader_dist_cjs_js_node_modules_babel_loader_lib_index_js_node_modules_ts_loader_index_js_clonedRuleSet_86_use_2_node_modules_vue_loader_dist_index_js_ruleSet_0_use_0_Button_vue_vue_type_script_lang_ts__WEBPACK_IMPORTED_MODULE_0__["default"]; }
/* harmony export */ });
/* harmony import */ var _node_modules_thread_loader_dist_cjs_js_node_modules_babel_loader_lib_index_js_node_modules_ts_loader_index_js_clonedRuleSet_86_use_2_node_modules_vue_loader_dist_index_js_ruleSet_0_use_0_Button_vue_vue_type_script_lang_ts__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! -!../../../node_modules/thread-loader/dist/cjs.js!../../../node_modules/babel-loader/lib/index.js!../../../node_modules/ts-loader/index.js??clonedRuleSet-86.use[2]!../../../node_modules/vue-loader/dist/index.js??ruleSet[0].use[0]!./Button.vue?vue&type=script&lang=ts */ "./node_modules/thread-loader/dist/cjs.js!./node_modules/babel-loader/lib/index.js!./node_modules/ts-loader/index.js??clonedRuleSet-86.use[2]!./node_modules/vue-loader/dist/index.js??ruleSet[0].use[0]!./src/components/MyButton/Button.vue?vue&type=script&lang=ts");
 

/***/ }),

/***/ "./src/components/MyButton/Button.vue?vue&type=template&id=c6c550e8&scoped=true&ts=true":
/*!**********************************************************************************************!*\
  !*** ./src/components/MyButton/Button.vue?vue&type=template&id=c6c550e8&scoped=true&ts=true ***!
  \**********************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "render": function() { return /* reexport safe */ _node_modules_thread_loader_dist_cjs_js_node_modules_babel_loader_lib_index_js_node_modules_ts_loader_index_js_clonedRuleSet_86_use_2_node_modules_vue_loader_dist_templateLoader_js_ruleSet_1_rules_4_node_modules_vue_loader_dist_index_js_ruleSet_0_use_0_Button_vue_vue_type_template_id_c6c550e8_scoped_true_ts_true__WEBPACK_IMPORTED_MODULE_0__.render; }
/* harmony export */ });
/* harmony import */ var _node_modules_thread_loader_dist_cjs_js_node_modules_babel_loader_lib_index_js_node_modules_ts_loader_index_js_clonedRuleSet_86_use_2_node_modules_vue_loader_dist_templateLoader_js_ruleSet_1_rules_4_node_modules_vue_loader_dist_index_js_ruleSet_0_use_0_Button_vue_vue_type_template_id_c6c550e8_scoped_true_ts_true__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! -!../../../node_modules/thread-loader/dist/cjs.js!../../../node_modules/babel-loader/lib/index.js!../../../node_modules/ts-loader/index.js??clonedRuleSet-86.use[2]!../../../node_modules/vue-loader/dist/templateLoader.js??ruleSet[1].rules[4]!../../../node_modules/vue-loader/dist/index.js??ruleSet[0].use[0]!./Button.vue?vue&type=template&id=c6c550e8&scoped=true&ts=true */ "./node_modules/thread-loader/dist/cjs.js!./node_modules/babel-loader/lib/index.js!./node_modules/ts-loader/index.js??clonedRuleSet-86.use[2]!./node_modules/vue-loader/dist/templateLoader.js??ruleSet[1].rules[4]!./node_modules/vue-loader/dist/index.js??ruleSet[0].use[0]!./src/components/MyButton/Button.vue?vue&type=template&id=c6c550e8&scoped=true&ts=true");


/***/ }),

/***/ "./src/components/MyButton/Button.vue?vue&type=style&index=0&id=c6c550e8&scoped=true&lang=less":
/*!*****************************************************************************************************!*\
  !*** ./src/components/MyButton/Button.vue?vue&type=style&index=0&id=c6c550e8&scoped=true&lang=less ***!
  \*****************************************************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony import */ var _node_modules_vue_style_loader_index_js_clonedRuleSet_77_use_0_node_modules_css_loader_dist_cjs_js_clonedRuleSet_77_use_1_node_modules_vue_loader_dist_stylePostLoader_js_node_modules_postcss_loader_dist_cjs_js_clonedRuleSet_77_use_2_node_modules_postcss_loader_dist_cjs_js_clonedRuleSet_77_use_3_node_modules_less_loader_dist_cjs_js_clonedRuleSet_77_use_4_node_modules_vue_loader_dist_index_js_ruleSet_0_use_0_Button_vue_vue_type_style_index_0_id_c6c550e8_scoped_true_lang_less__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! -!../../../node_modules/vue-style-loader/index.js??clonedRuleSet-77.use[0]!../../../node_modules/css-loader/dist/cjs.js??clonedRuleSet-77.use[1]!../../../node_modules/vue-loader/dist/stylePostLoader.js!../../../node_modules/postcss-loader/dist/cjs.js??clonedRuleSet-77.use[2]!../../../node_modules/postcss-loader/dist/cjs.js??clonedRuleSet-77.use[3]!../../../node_modules/less-loader/dist/cjs.js??clonedRuleSet-77.use[4]!../../../node_modules/vue-loader/dist/index.js??ruleSet[0].use[0]!./Button.vue?vue&type=style&index=0&id=c6c550e8&scoped=true&lang=less */ "./node_modules/vue-style-loader/index.js??clonedRuleSet-77.use[0]!./node_modules/css-loader/dist/cjs.js??clonedRuleSet-77.use[1]!./node_modules/vue-loader/dist/stylePostLoader.js!./node_modules/postcss-loader/dist/cjs.js??clonedRuleSet-77.use[2]!./node_modules/postcss-loader/dist/cjs.js??clonedRuleSet-77.use[3]!./node_modules/less-loader/dist/cjs.js??clonedRuleSet-77.use[4]!./node_modules/vue-loader/dist/index.js??ruleSet[0].use[0]!./src/components/MyButton/Button.vue?vue&type=style&index=0&id=c6c550e8&scoped=true&lang=less");
/* harmony import */ var _node_modules_vue_style_loader_index_js_clonedRuleSet_77_use_0_node_modules_css_loader_dist_cjs_js_clonedRuleSet_77_use_1_node_modules_vue_loader_dist_stylePostLoader_js_node_modules_postcss_loader_dist_cjs_js_clonedRuleSet_77_use_2_node_modules_postcss_loader_dist_cjs_js_clonedRuleSet_77_use_3_node_modules_less_loader_dist_cjs_js_clonedRuleSet_77_use_4_node_modules_vue_loader_dist_index_js_ruleSet_0_use_0_Button_vue_vue_type_style_index_0_id_c6c550e8_scoped_true_lang_less__WEBPACK_IMPORTED_MODULE_0___default = /*#__PURE__*/__webpack_require__.n(_node_modules_vue_style_loader_index_js_clonedRuleSet_77_use_0_node_modules_css_loader_dist_cjs_js_clonedRuleSet_77_use_1_node_modules_vue_loader_dist_stylePostLoader_js_node_modules_postcss_loader_dist_cjs_js_clonedRuleSet_77_use_2_node_modules_postcss_loader_dist_cjs_js_clonedRuleSet_77_use_3_node_modules_less_loader_dist_cjs_js_clonedRuleSet_77_use_4_node_modules_vue_loader_dist_index_js_ruleSet_0_use_0_Button_vue_vue_type_style_index_0_id_c6c550e8_scoped_true_lang_less__WEBPACK_IMPORTED_MODULE_0__);
/* harmony reexport (unknown) */ var __WEBPACK_REEXPORT_OBJECT__ = {};
/* harmony reexport (unknown) */ for(var __WEBPACK_IMPORT_KEY__ in _node_modules_vue_style_loader_index_js_clonedRuleSet_77_use_0_node_modules_css_loader_dist_cjs_js_clonedRuleSet_77_use_1_node_modules_vue_loader_dist_stylePostLoader_js_node_modules_postcss_loader_dist_cjs_js_clonedRuleSet_77_use_2_node_modules_postcss_loader_dist_cjs_js_clonedRuleSet_77_use_3_node_modules_less_loader_dist_cjs_js_clonedRuleSet_77_use_4_node_modules_vue_loader_dist_index_js_ruleSet_0_use_0_Button_vue_vue_type_style_index_0_id_c6c550e8_scoped_true_lang_less__WEBPACK_IMPORTED_MODULE_0__) if(__WEBPACK_IMPORT_KEY__ !== "default") __WEBPACK_REEXPORT_OBJECT__[__WEBPACK_IMPORT_KEY__] = function(key) { return _node_modules_vue_style_loader_index_js_clonedRuleSet_77_use_0_node_modules_css_loader_dist_cjs_js_clonedRuleSet_77_use_1_node_modules_vue_loader_dist_stylePostLoader_js_node_modules_postcss_loader_dist_cjs_js_clonedRuleSet_77_use_2_node_modules_postcss_loader_dist_cjs_js_clonedRuleSet_77_use_3_node_modules_less_loader_dist_cjs_js_clonedRuleSet_77_use_4_node_modules_vue_loader_dist_index_js_ruleSet_0_use_0_Button_vue_vue_type_style_index_0_id_c6c550e8_scoped_true_lang_less__WEBPACK_IMPORTED_MODULE_0__[key]; }.bind(0, __WEBPACK_IMPORT_KEY__)
/* harmony reexport (unknown) */ __webpack_require__.d(__webpack_exports__, __WEBPACK_REEXPORT_OBJECT__);


/***/ }),

/***/ "./node_modules/vue-style-loader/index.js??clonedRuleSet-77.use[0]!./node_modules/css-loader/dist/cjs.js??clonedRuleSet-77.use[1]!./node_modules/vue-loader/dist/stylePostLoader.js!./node_modules/postcss-loader/dist/cjs.js??clonedRuleSet-77.use[2]!./node_modules/postcss-loader/dist/cjs.js??clonedRuleSet-77.use[3]!./node_modules/less-loader/dist/cjs.js??clonedRuleSet-77.use[4]!./node_modules/vue-loader/dist/index.js??ruleSet[0].use[0]!./src/components/MyButton/Button.vue?vue&type=style&index=0&id=c6c550e8&scoped=true&lang=less":
/*!*********************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************!*\
  !*** ./node_modules/vue-style-loader/index.js??clonedRuleSet-77.use[0]!./node_modules/css-loader/dist/cjs.js??clonedRuleSet-77.use[1]!./node_modules/vue-loader/dist/stylePostLoader.js!./node_modules/postcss-loader/dist/cjs.js??clonedRuleSet-77.use[2]!./node_modules/postcss-loader/dist/cjs.js??clonedRuleSet-77.use[3]!./node_modules/less-loader/dist/cjs.js??clonedRuleSet-77.use[4]!./node_modules/vue-loader/dist/index.js??ruleSet[0].use[0]!./src/components/MyButton/Button.vue?vue&type=style&index=0&id=c6c550e8&scoped=true&lang=less ***!
  \*********************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************************/
/***/ (function(module, __unused_webpack_exports, __webpack_require__) {

// style-loader: Adds some css to the DOM by adding a <style> tag

// load the styles
var content = __webpack_require__(/*! !!../../../node_modules/css-loader/dist/cjs.js??clonedRuleSet-77.use[1]!../../../node_modules/vue-loader/dist/stylePostLoader.js!../../../node_modules/postcss-loader/dist/cjs.js??clonedRuleSet-77.use[2]!../../../node_modules/postcss-loader/dist/cjs.js??clonedRuleSet-77.use[3]!../../../node_modules/less-loader/dist/cjs.js??clonedRuleSet-77.use[4]!../../../node_modules/vue-loader/dist/index.js??ruleSet[0].use[0]!./Button.vue?vue&type=style&index=0&id=c6c550e8&scoped=true&lang=less */ "./node_modules/css-loader/dist/cjs.js??clonedRuleSet-77.use[1]!./node_modules/vue-loader/dist/stylePostLoader.js!./node_modules/postcss-loader/dist/cjs.js??clonedRuleSet-77.use[2]!./node_modules/postcss-loader/dist/cjs.js??clonedRuleSet-77.use[3]!./node_modules/less-loader/dist/cjs.js??clonedRuleSet-77.use[4]!./node_modules/vue-loader/dist/index.js??ruleSet[0].use[0]!./src/components/MyButton/Button.vue?vue&type=style&index=0&id=c6c550e8&scoped=true&lang=less");
if(content.__esModule) content = content.default;
if(typeof content === 'string') content = [[module.id, content, '']];
if(content.locals) module.exports = content.locals;
// add the styles to the DOM
var add = (__webpack_require__(/*! !../../../node_modules/vue-style-loader/lib/addStylesClient.js */ "./node_modules/vue-style-loader/lib/addStylesClient.js")["default"])
var update = add("1bb52e1e", content, true, {"sourceMap":false,"shadowMode":false});

/***/ }),

/***/ "./node_modules/vue-style-loader/lib/addStylesClient.js":
/*!**************************************************************!*\
  !*** ./node_modules/vue-style-loader/lib/addStylesClient.js ***!
  \**************************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "default": function() { return /* binding */ addStylesClient; }
/* harmony export */ });
/* harmony import */ var _listToStyles__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./listToStyles */ "./node_modules/vue-style-loader/lib/listToStyles.js");
/*
  MIT License http://www.opensource.org/licenses/mit-license.php
  Author Tobias Koppers @sokra
  Modified by Evan You @yyx990803
*/



var hasDocument = typeof document !== 'undefined'

if (typeof DEBUG !== 'undefined' && DEBUG) {
  if (!hasDocument) {
    throw new Error(
    'vue-style-loader cannot be used in a non-browser environment. ' +
    "Use { target: 'node' } in your Webpack config to indicate a server-rendering environment."
  ) }
}

/*
type StyleObject = {
  id: number;
  parts: Array<StyleObjectPart>
}

type StyleObjectPart = {
  css: string;
  media: string;
  sourceMap: ?string
}
*/

var stylesInDom = {/*
  [id: number]: {
    id: number,
    refs: number,
    parts: Array<(obj?: StyleObjectPart) => void>
  }
*/}

var head = hasDocument && (document.head || document.getElementsByTagName('head')[0])
var singletonElement = null
var singletonCounter = 0
var isProduction = false
var noop = function () {}
var options = null
var ssrIdKey = 'data-vue-ssr-id'

// Force single-tag solution on IE6-9, which has a hard limit on the # of <style>
// tags it will allow on a page
var isOldIE = typeof navigator !== 'undefined' && /msie [6-9]\b/.test(navigator.userAgent.toLowerCase())

function addStylesClient (parentId, list, _isProduction, _options) {
  isProduction = _isProduction

  options = _options || {}

  var styles = (0,_listToStyles__WEBPACK_IMPORTED_MODULE_0__["default"])(parentId, list)
  addStylesToDom(styles)

  return function update (newList) {
    var mayRemove = []
    for (var i = 0; i < styles.length; i++) {
      var item = styles[i]
      var domStyle = stylesInDom[item.id]
      domStyle.refs--
      mayRemove.push(domStyle)
    }
    if (newList) {
      styles = (0,_listToStyles__WEBPACK_IMPORTED_MODULE_0__["default"])(parentId, newList)
      addStylesToDom(styles)
    } else {
      styles = []
    }
    for (var i = 0; i < mayRemove.length; i++) {
      var domStyle = mayRemove[i]
      if (domStyle.refs === 0) {
        for (var j = 0; j < domStyle.parts.length; j++) {
          domStyle.parts[j]()
        }
        delete stylesInDom[domStyle.id]
      }
    }
  }
}

function addStylesToDom (styles /* Array<StyleObject> */) {
  for (var i = 0; i < styles.length; i++) {
    var item = styles[i]
    var domStyle = stylesInDom[item.id]
    if (domStyle) {
      domStyle.refs++
      for (var j = 0; j < domStyle.parts.length; j++) {
        domStyle.parts[j](item.parts[j])
      }
      for (; j < item.parts.length; j++) {
        domStyle.parts.push(addStyle(item.parts[j]))
      }
      if (domStyle.parts.length > item.parts.length) {
        domStyle.parts.length = item.parts.length
      }
    } else {
      var parts = []
      for (var j = 0; j < item.parts.length; j++) {
        parts.push(addStyle(item.parts[j]))
      }
      stylesInDom[item.id] = { id: item.id, refs: 1, parts: parts }
    }
  }
}

function createStyleElement () {
  var styleElement = document.createElement('style')
  styleElement.type = 'text/css'
  head.appendChild(styleElement)
  return styleElement
}

function addStyle (obj /* StyleObjectPart */) {
  var update, remove
  var styleElement = document.querySelector('style[' + ssrIdKey + '~="' + obj.id + '"]')

  if (styleElement) {
    if (isProduction) {
      // has SSR styles and in production mode.
      // simply do nothing.
      return noop
    } else {
      // has SSR styles but in dev mode.
      // for some reason Chrome can't handle source map in server-rendered
      // style tags - source maps in <style> only works if the style tag is
      // created and inserted dynamically. So we remove the server rendered
      // styles and inject new ones.
      styleElement.parentNode.removeChild(styleElement)
    }
  }

  if (isOldIE) {
    // use singleton mode for IE9.
    var styleIndex = singletonCounter++
    styleElement = singletonElement || (singletonElement = createStyleElement())
    update = applyToSingletonTag.bind(null, styleElement, styleIndex, false)
    remove = applyToSingletonTag.bind(null, styleElement, styleIndex, true)
  } else {
    // use multi-style-tag mode in all other cases
    styleElement = createStyleElement()
    update = applyToTag.bind(null, styleElement)
    remove = function () {
      styleElement.parentNode.removeChild(styleElement)
    }
  }

  update(obj)

  return function updateStyle (newObj /* StyleObjectPart */) {
    if (newObj) {
      if (newObj.css === obj.css &&
          newObj.media === obj.media &&
          newObj.sourceMap === obj.sourceMap) {
        return
      }
      update(obj = newObj)
    } else {
      remove()
    }
  }
}

var replaceText = (function () {
  var textStore = []

  return function (index, replacement) {
    textStore[index] = replacement
    return textStore.filter(Boolean).join('\n')
  }
})()

function applyToSingletonTag (styleElement, index, remove, obj) {
  var css = remove ? '' : obj.css

  if (styleElement.styleSheet) {
    styleElement.styleSheet.cssText = replaceText(index, css)
  } else {
    var cssNode = document.createTextNode(css)
    var childNodes = styleElement.childNodes
    if (childNodes[index]) styleElement.removeChild(childNodes[index])
    if (childNodes.length) {
      styleElement.insertBefore(cssNode, childNodes[index])
    } else {
      styleElement.appendChild(cssNode)
    }
  }
}

function applyToTag (styleElement, obj) {
  var css = obj.css
  var media = obj.media
  var sourceMap = obj.sourceMap

  if (media) {
    styleElement.setAttribute('media', media)
  }
  if (options.ssrId) {
    styleElement.setAttribute(ssrIdKey, obj.id)
  }

  if (sourceMap) {
    // https://developer.chrome.com/devtools/docs/javascript-debugging
    // this makes source maps inside style tags work properly in Chrome
    css += '\n/*# sourceURL=' + sourceMap.sources[0] + ' */'
    // http://stackoverflow.com/a/26603875
    css += '\n/*# sourceMappingURL=data:application/json;base64,' + btoa(unescape(encodeURIComponent(JSON.stringify(sourceMap)))) + ' */'
  }

  if (styleElement.styleSheet) {
    styleElement.styleSheet.cssText = css
  } else {
    while (styleElement.firstChild) {
      styleElement.removeChild(styleElement.firstChild)
    }
    styleElement.appendChild(document.createTextNode(css))
  }
}


/***/ }),

/***/ "./node_modules/vue-style-loader/lib/listToStyles.js":
/*!***********************************************************!*\
  !*** ./node_modules/vue-style-loader/lib/listToStyles.js ***!
  \***********************************************************/
/***/ (function(__unused_webpack_module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "default": function() { return /* binding */ listToStyles; }
/* harmony export */ });
/**
 * Translates the list format produced by css-loader into something
 * easier to manipulate.
 */
function listToStyles (parentId, list) {
  var styles = []
  var newStyles = {}
  for (var i = 0; i < list.length; i++) {
    var item = list[i]
    var id = item[0]
    var css = item[1]
    var media = item[2]
    var sourceMap = item[3]
    var part = {
      id: parentId + ':' + i,
      css: css,
      media: media,
      sourceMap: sourceMap
    }
    if (!newStyles[id]) {
      styles.push(newStyles[id] = { id: id, parts: [part] })
    } else {
      newStyles[id].parts.push(part)
    }
  }
  return styles
}


/***/ }),

/***/ "vue":
/*!**********************!*\
  !*** external "vue" ***!
  \**********************/
/***/ (function(module) {

"use strict";
module.exports = require("vue");

/***/ })

/******/ 	});
/************************************************************************/
/******/ 	// The module cache
/******/ 	var __webpack_module_cache__ = {};
/******/ 	
/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {
/******/ 		// Check if module is in cache
/******/ 		var cachedModule = __webpack_module_cache__[moduleId];
/******/ 		if (cachedModule !== undefined) {
/******/ 			return cachedModule.exports;
/******/ 		}
/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = __webpack_module_cache__[moduleId] = {
/******/ 			id: moduleId,
/******/ 			// no module.loaded needed
/******/ 			exports: {}
/******/ 		};
/******/ 	
/******/ 		// Execute the module function
/******/ 		__webpack_modules__[moduleId](module, module.exports, __webpack_require__);
/******/ 	
/******/ 		// Return the exports of the module
/******/ 		return module.exports;
/******/ 	}
/******/ 	
/************************************************************************/
/******/ 	/* webpack/runtime/compat get default export */
/******/ 	!function() {
/******/ 		// getDefaultExport function for compatibility with non-harmony modules
/******/ 		__webpack_require__.n = function(module) {
/******/ 			var getter = module && module.__esModule ?
/******/ 				function() { return module['default']; } :
/******/ 				function() { return module; };
/******/ 			__webpack_require__.d(getter, { a: getter });
/******/ 			return getter;
/******/ 		};
/******/ 	}();
/******/ 	
/******/ 	/* webpack/runtime/define property getters */
/******/ 	!function() {
/******/ 		// define getter functions for harmony exports
/******/ 		__webpack_require__.d = function(exports, definition) {
/******/ 			for(var key in definition) {
/******/ 				if(__webpack_require__.o(definition, key) && !__webpack_require__.o(exports, key)) {
/******/ 					Object.defineProperty(exports, key, { enumerable: true, get: definition[key] });
/******/ 				}
/******/ 			}
/******/ 		};
/******/ 	}();
/******/ 	
/******/ 	/* webpack/runtime/hasOwnProperty shorthand */
/******/ 	!function() {
/******/ 		__webpack_require__.o = function(obj, prop) { return Object.prototype.hasOwnProperty.call(obj, prop); }
/******/ 	}();
/******/ 	
/******/ 	/* webpack/runtime/make namespace object */
/******/ 	!function() {
/******/ 		// define __esModule on exports
/******/ 		__webpack_require__.r = function(exports) {
/******/ 			if(typeof Symbol !== 'undefined' && Symbol.toStringTag) {
/******/ 				Object.defineProperty(exports, Symbol.toStringTag, { value: 'Module' });
/******/ 			}
/******/ 			Object.defineProperty(exports, '__esModule', { value: true });
/******/ 		};
/******/ 	}();
/******/ 	
/******/ 	/* webpack/runtime/publicPath */
/******/ 	!function() {
/******/ 		__webpack_require__.p = "";
/******/ 	}();
/******/ 	
/************************************************************************/
var __webpack_exports__ = {};
// This entry need to be wrapped in an IIFE because it need to be in strict mode.
!function() {
"use strict";
/*!**********************************************************************************!*\
  !*** ./node_modules/@vue/cli-service/lib/commands/build/entry-lib-no-default.js ***!
  \**********************************************************************************/
__webpack_require__.r(__webpack_exports__);
/* harmony export */ __webpack_require__.d(__webpack_exports__, {
/* harmony export */   "MyButton": function() { return /* reexport safe */ _entry__WEBPACK_IMPORTED_MODULE_1__.MyButton; },
/* harmony export */   "getName": function() { return /* reexport safe */ _entry__WEBPACK_IMPORTED_MODULE_1__.getName; },
/* harmony export */   "install": function() { return /* reexport safe */ _entry__WEBPACK_IMPORTED_MODULE_1__.install; },
/* harmony export */   "withInstall": function() { return /* reexport safe */ _entry__WEBPACK_IMPORTED_MODULE_1__.withInstall; }
/* harmony export */ });
/* harmony import */ var _setPublicPath__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./setPublicPath */ "./node_modules/@vue/cli-service/lib/commands/build/setPublicPath.js");
/* harmony import */ var _entry__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ~entry */ "./src/index.ts");



}();
/******/ 	return __webpack_exports__;
/******/ })()
;
});