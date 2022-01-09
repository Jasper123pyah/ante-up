import http from 'k6/http';
import { sleep } from 'k6';

export const options = {
    duration: '1m',
    vus: 50,
    thresholds: {
        http_req_duration: ['p(99)<200'],
        http_req_duration: ['p(95)<150'],
        http_req_failed:['rate<0.01']
    },
};

export default function () {
    const res = http.get('http://78.47.219.206:420/game');
    sleep(1);
}