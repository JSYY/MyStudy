import axios from 'axios';

class HttpWrapperService {
    interceptor() {
        axios.interceptors.request.use(config => {
            return config
        }, error => {
            return Promise.reject(error)
        });
        axios.interceptors.response.use(response => {
            return response
        }, error => {
            return Promise.resolve(error.response)
        })
    }

    checkStatus(response:any) {
        if (response && (response.status === 200 || response.status === 304 || response.status === 204)) {
            return response
        }
        else {
            return response;
        }
    }

    post(url:any, data:any) {
        return axios({
            url: url,
            data: data,
            method: 'post',
            timeout: 10000,
            headers: {
                'X-Requested-With': 'XMLHttpRequest',
                'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8'
            }
        }).then(
            (response) => {
                return this.checkStatus(response)
            }
        )
    }

    get(url:any,data = null) {
        return axios({
            url: url,
            params: data,
            method: 'get',
            timeout: 10000,
            headers: {
                'X-Requested-With': 'XMLHttpRequest'
            }
        }).then(
            (response) => {
                return this.checkStatus(response)
            }
        )
    }
}
let HttpServices = new HttpWrapperService();
export { HttpServices }