<template>
    <div>
        <div>
            <video autoplay playsinline ref="localVideo" controls ></video>
            <div>local video</div>
        </div>
        <div>
            <video autoplay playsinline ref="remoteVideo" controls></video>
            <div>remote video</div>
        </div>
        <button @click="send">send</button>
        <button @click="opencamera">open camera</button>
    </div>
</template>

<script lang="ts">
    import { onMounted, onUnmounted,ref, watch } from 'vue';
    import io from 'socket.io-client';

    export default {
        name: 'WebRTC',
        props: {
            name: String,
        },
        setup(props) {
            let localVideo = ref();
            let remoteVideo = ref();
            let socket: any;
            let stream;
            let localPc;
            let show = ref(false);

            watch(() => props.name, (n, o) => {
                if (n) {
                    //show.value = n === 'remote';
                }
            }, {
                deep: true,
                immediate: true
            });

            onMounted(() => {

                socket = io('http://10.5.78.13:9001', {
                    path: '/rtc',
                    query: { username: props.name, room: '1' },
                }).connect();

                socket.on('userlist', async (res) => {
                    // 房间少于两人时 对方掉线 则关闭对方视频
                    if (res.length < 2) {
                        return;
                    }
                    //sendOffer();
                });

                socket.on('offer', async (offer) => {
                    console.log(`receive offer`, offer)
                    sendAnswer(offer);
                });

                socket.on('answer', async (answer) => {
                    console.log(`receive answer`, answer)
                    // 完善本地remote描述
                    await localPc.setRemoteDescription(answer)
                })

                socket.on('candidate', async ({ pc, candidate }) => {
                    // 添加ice
                    localPc.ontrack = (e) => {
                        remoteVideo.value.srcObject = e.streams[0];
                    }
                    await localPc.addIceCandidate(candidate);
                })
            });

            function send() {
                sendOffer();
            }

            async function sendOffer() {
                // 初始化当前视频
                localPc = new RTCPeerConnection();
                localPc.createDataChannel('test');
                // 添加RTC流
                if (stream) {
                    stream.getTracks().forEach((track) => {
                        localPc.addTrack(track, stream)
                    })
                } 
                
                // 给当前RTC流设置监听事件(协议完成回调)
                localPc.onicecandidate = (event) => {
                    console.log('localPc:', event.candidate, event)
                    // 回调时，将自己candidate发给对方，对方可以直接addIceCandidate(candidate)添加可以获取流
                    if (event.candidate)
                        socket.emit('candidate', '1', {
                            pc: 'local',
                            candidate: event.candidate,
                        })
                }
                // 发起方：创建offer(成功将offer的设置当前流，并发送给接收方)
                let offer = await localPc.createOffer();
                // 建立连接，此时就会触发onicecandidate，然后注册ontrack
                await localPc.setLocalDescription(offer);
                socket.emit('offer', '1', offer);
            }

            function opencamera() {
                initVideo();
            }

            async function initVideo() {
                stream = await navigator.mediaDevices.getUserMedia({ audio: false, video: { width: 400, height: 400 } });
                localVideo.value.srcObject = stream;
            }

            async function sendAnswer(offer) {
                localPc = new RTCPeerConnection(null);
                localPc.createDataChannel('test');

                //添加RTC流
                if (stream) {
                    stream.getTracks().forEach((track) => {
                        localPc.addTrack(track, stream)
                    })
                }

                localPc.onicecandidate = (event) => {
                    // 回调时，将自己candidate发给对方，对方可以直接addIceCandidate(candidate)添加可以获取流
                    if (event.candidate)
                        socket.emit('candidate', '1', {
                            pc: 'remote',
                            candidate: event.candidate,
                        })
                }
                await localPc.setRemoteDescription(offer)
                const answer = await localPc.createAnswer()
                await localPc.setLocalDescription(answer)
                socket.emit('answer', '1', answer)
            }

            onUnmounted(() => {
                socket.disconnect();

            });

            return{
                localVideo, remoteVideo, send, show, opencamera
            }
        }
}
</script>

<style scoped lang="scss">

</style>
