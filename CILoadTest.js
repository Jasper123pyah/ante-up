import http from 'k6/http';
import { sleep } from 'k6';

export const options = {
    duration: '1m',
    vus: 50,
};

export default function () {
    const res = http.get('http://78.47.219.206:420/game');
    sleep(1);
}