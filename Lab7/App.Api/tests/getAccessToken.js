const axios = require('axios')

async function getAccessToken() {
    try {
        const response = await axios.post('https://dev-qyulsuvmi4i083bm.us.auth0.com/oauth/token', {
            client_id: '2bIsALcPDhQN6GJ1RG6JHkMS3JftH1W8',
            client_secret: '',
            audience: 'lab6Api',
            grant_type: 'client_credentials',
        });
        return response.data.access_token;
    } catch (error) {
        console.error('Failed to retrieve access token:', error.response?.data || error.message);
        throw new Error('Unable to get access token');
    }
}

module.exports = getAccessToken;
