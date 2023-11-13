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
                name:"counts",
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
                name:'counts',
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
            },
            dataZoom : [
                {
                    type: 'slider',
                    show: true,
                    start: 0,
                    end: 100,
                },
            ],
            brush: {  
                xAxisIndex: 0,
                throttleType: "debounce", //开启选中延迟后调用回调延迟 
                throttleDelay: 600, //选中延迟后调用回调延迟时
                brushStyle: {                  
                   borderWidth: 2,                    
                   color: 'rgba(248,231,28,0.10)',                    
                   borderColor: '#F8E71C'  
                },
                transformable:false  //设置是否可以拖动          
            },
            toolbox: {                
                show: false, //可以设置不同的按钮           
            },    
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

        //设置框选范围
        function setBrushPosition(x1:number,x2:number){
            EChart.dispatchAction({
                type:'brush',
                areas:[
                    {
                        xAxisIndex:0,
                        brushType:'lineX',
                        coordRange:[x1,x2],
                    }
                ],
            });
        }

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
