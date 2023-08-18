<template>
    <div class="background rowCenterCenter">
        <button @click="start">start</button>
        <button @click="call">call</button>
        <button @click="stop">stop</button>
        <video id="localVideo" autoplay playsinline></video>
        <video id="remoteVideo" autoplay playsinline></video>
    </div>
</template>

<script lang="ts">
    import { onMounted, onBeforeUnmount } from "@vue/runtime-core";

    export default {
        name: 'Camera',
        setup() {
            let localStream;
            let pc1;
            let pc2;
            let localVideo;
            let remoteVideo;
            const offerOptions = {
                offerToReceiveAudio: 1,
                offerToReceiveVideo: 1
            };

            onMounted(() => {
                //openCamera();
            });

            onBeforeUnmount(() => {
                //stop();
            });


            function start() {
                navigator.mediaDevices.getUserMedia({ audio: false, video: { width: 400, height: 400 } }).then((res: MediaStream) => {
                    localVideo = document.getElementById('localVideo') as HTMLVideoElement;
                    remoteVideo = document.getElementById('remoteVideo');
                    localStream = res;
                    if (localVideo) {
                        localVideo.srcObject = res;
                    }
                });
            }

            function stop() {
                const tracks = localStream.getTracks();

                tracks.forEach((track: any) => {
                    track.stop();
                });
                remoteVideo.srcObject = null;
                localVideo.srcObject = null;
            }

            async function call() {
                const configuration = {};
                const videoTracks = localStream.getVideoTracks();
                const audioTracks = localStream.getAudioTracks();

                pc1 = new RTCPeerConnection(configuration);
                pc1.addEventListener('icecandidate', e => onIceCandidate(pc1, e));
                pc2 = new RTCPeerConnection(configuration);
                pc2.addEventListener('icecandidate', e => onIceCandidate(pc2, e));
                pc1.addEventListener('iceconnectionstatechange', e => onIceStateChange(pc1, e));
                pc2.addEventListener('iceconnectionstatechange', e => onIceStateChange(pc2, e));
                pc2.addEventListener('track', gotRemoteStream);

                localStream.getTracks().forEach(track => pc1.addTrack(track, localStream));
                try {
                    const offer = await pc1.createOffer(offerOptions);
                    await onCreateOfferSuccess(offer);
                } catch (e) {
                    onCreateSessionDescriptionError(e);
                }
            }

            function onCreateSessionDescriptionError(error) {
                console.log(`Failed to create session description: ${error.toString()}`);
            }

            async function onCreateOfferSuccess(desc) {
                try {
                    await pc1.setLocalDescription(desc);
                } catch (e) {
                    onSetSessionDescriptionError(e);
                }
                try {
                    await pc2.setRemoteDescription(desc);
                    onSetRemoteSuccess(pc2);
                } catch (e) {
                    onSetSessionDescriptionError(e);
                }
                try {
                    const answer = await pc2.createAnswer();
                    await onCreateAnswerSuccess(answer);
                } catch (e) {
                    onCreateSessionDescriptionError(e);
                }
            }

            function onSetLocalSuccess(pc) {
                console.log(`${getName(pc)} setLocalDescription complete`);
            }

            function onSetRemoteSuccess(pc) {
                console.log(`${getName(pc)} setRemoteDescription complete`);
            }

            function onSetSessionDescriptionError(error) {
                console.log(`Failed to set session description: ${error.toString()}`);
            }

            function gotRemoteStream(e) {
                if (remoteVideo.srcObject !== e.streams[0]) {
                    remoteVideo.srcObject = e.streams[0];
                    console.log('pc2 received remote stream');
                }
            }

            async function onCreateAnswerSuccess(desc) {
                console.log(`Answer from pc2:\n${desc.sdp}`);
                console.log('pc2 setLocalDescription start');
                try {
                    await pc2.setLocalDescription(desc);
                    onSetLocalSuccess(pc2);
                } catch (e) {
                    onSetSessionDescriptionError(e);
                }
                console.log('pc1 setRemoteDescription start');
                try {
                    await pc1.setRemoteDescription(desc);
                    onSetRemoteSuccess(pc1);
                } catch (e) {
                    onSetSessionDescriptionError(e);
                }
            }

            function getName(pc) {
                return (pc === pc1) ? 'pc1' : 'pc2';
            }

            function getOtherPc(pc) {
                return (pc === pc1) ? pc2 : pc1;
            }

            async function onIceCandidate(pc, event) {
                try {
                    await (getOtherPc(pc).addIceCandidate(event.candidate));
                    onAddIceCandidateSuccess(pc);
                } catch (e) {
                    onAddIceCandidateError(pc, e);
                }
                console.log(`${getName(pc)} ICE candidate:\n${event.candidate ? event.candidate.candidate : '(null)'}`);
            }

            function onAddIceCandidateSuccess(pc) {
                console.log(`${getName(pc)} addIceCandidate success`);
            }

            function onAddIceCandidateError(pc, error) {
                console.log(`${getName(pc)} failed to add ICE Candidate: ${error.toString()}`);
            }

            function onIceStateChange(pc, event) {
                if (pc) {
                    console.log(`${getName(pc)} ICE state: ${pc.iceConnectionState}`);
                    console.log('ICE state change event: ', event);
                }
            }

            return {
                start, call, stop
            }
        },
    }
</script>

<style scoped>
    #video-canvas {
    }

    .background {
        background-color: black;
        width: 100%;
        height: 100%;
        border-radius: 4px;
        overflow: hidden;
    }
</style>
