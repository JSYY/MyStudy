import * as echarts from 'echarts';
import { onMounted, onUnmounted, ref, watch } from "vue";

export default {
    name:'EcharsBox',
    props:{
        
    },
    setup(props: any) {
        let EChart: any;
        let changeDataInterval: any;
        let config = {
            xAxis: {
                type: 'category',
                data: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun'],
                axisLabel:{
                    show:true,
                    textStyle:{
                        color:"#FFFFFF",
                        fontSize:'16'
                    }
                }
            },
            yAxis:[ {
                name:"计数率kcps",
                nameTextStyle:{
                    color:"#FFFFFF",
                    fontSize:'16'
                },
                type: 'value',
                axisLabel:{
                    show:true,
                    textStyle:{
                        color:"#FFFFFF",
                        fontSize:'16'
                    }
                }
            }],
            series: [{
                name:'计数率kcps',
                data: [820, 932, 901, 934, 1290, 1330, 1320],
                type: 'line',
                smooth: true,
                itemStyle : { normal: {label : {
                    show: true,
                    textStyle : {
                        fontSize : '14',
                        color:"#FFFFFF"
                    }
                }}},
                lineStyle:{ normal:{ color: "#44D7B6" } },
                areaStyle: {
                    color: {
                        type: 'linear',
                        x: 0,
                        y: 0,
                        x2: 0,
                        y2: 1,
                        colorStops: [{
                            offset: 0, color: 'rgba(58,132,255, 0.5)' // 0% 处的颜色
                        }, {
                            offset: 1, color: 'rgba(58,132,255, 0)' // 100% 处的颜色
                        }],
                        global: false // 缺省为 false
                    }
                },
            }],
            grid:{
                x:50,
                y:50,
                x2:30,
                y2:50,
                borderWidth:1
            }
        };

        onMounted(()=>{
            Init();
            changeDataInterval =setInterval(changeData,1000);
        })

        onUnmounted(()=>{
            clearInterval(changeDataInterval);
            changeDataInterval=null;
            EChart.dispose();
            EChart=null;
        })

        function Init(){
            EChart = echarts.init(document.getElementById("EChart"));
            EChart.setOption(config);
        }

        function changeData(){
            config.series[0].data=[Number((Math.random()*1000).toFixed(2)),
                Number((Math.random()*1000).toFixed(2)),
                Number((Math.random()*1000).toFixed(2)),
                Number((Math.random()*1000).toFixed(2)),
                Number((Math.random()*1000).toFixed(2)),
                Number((Math.random()*1000).toFixed(2)),
                Number((Math.random()*1000).toFixed(2))];
            EChart.setOption(config);
        }

        return {
            
        }
    }
}
