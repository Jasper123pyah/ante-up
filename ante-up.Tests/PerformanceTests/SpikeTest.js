import http from 'k6/http';
import {sleep, check} from 'k6';

export let options = {
    insecureSkipTLSVerify: true,
    noConnectionReuse: false,
    stages: [
        {duration: '10s', target:100},
        {duration: '1m', target:100},
        {duration: '10s', target:1500},
        {duration: '3m', target:1500},
        {duration: '10s', target:100},
        {duration: '3m', target:100},
        {duration: '10s', target:0},
    ]
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
