import http from 'k6/http';
import {sleep, check} from 'k6';

export let options = {
    insecureSkipTLSVerify: true,
    noConnectionReuse: false,
    stages: [
        {duration: '5m', target:150},
        {duration: '10m', target:150},
        {duration: '5m', target:0},
    ],
    thresholds:{
        http_req_duration: ['p(99)<200'],
        http_req_failed:['rate<0.01']
    }
}

const BASE_URL = 'http://78.47.219.206:420';

export default () => {
    const responses = http.batch([
        ['GET', `${BASE_URL}/game`],
        ['GET', `${BASE_URL}/game/names`],
        ['POST', `${BASE_URL}/account/register`, null, {username: 'username', password: 'password', email: 'email'}]
    ])
    check(responses[0], {
        'main page status was 200': (res) => res.status === 200,
    });
    sleep(1);
}
