import http from 'k6/http';
import {sleep, check} from 'k6';

export let options = {
    insecureSkipTLSVerify: true,
    noConnectionReuse: false,
    stages: [
        {duration: '2m', target:100},
        {duration: '5m', target:100},
        {duration: '2m', target:200},
        {duration: '5m', target:200},
        {duration: '2m', target:300},
        {duration: '5m', target:300},
        {duration: '2m', target:400},
        {duration: '5m', target:400},
        {duration: '10m', target:0},
    ]
}

const BASE_URL = 'https://localhost:5001';

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
