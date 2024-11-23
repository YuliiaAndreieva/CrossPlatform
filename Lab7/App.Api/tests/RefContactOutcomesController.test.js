const request = require('supertest');
const getAccessToken = require('./getAccessToken');

const API_URL = 'http://localhost:3001';

describe('RefContactOutcomesController', () => {
    let accessToken;
    
    beforeAll(async () => {
        accessToken = await getAccessToken();
    });
    
    it('should return a list of contact outcomes', async () => {
        const response = await request(API_URL)
            .get('/api/ref-contact-outcomes')
            .set('Authorization', `Bearer ${accessToken}`);

        expect(response.statusCode).toBe(200);
        expect(Array.isArray(response.body)).toBe(true);
        response.body.forEach((outcome) => {
            expect(outcome).toHaveProperty('outcomeStatusCode');
            expect(outcome).toHaveProperty('outcomeStatusDescription');
        });
    });

    it('should return a specific contact outcome by code', async () => {
        const code = 101; 
        const response = await request(API_URL)
            .get(`/api/ref-contact-outcomes/${code}`)
            .set('Authorization', `Bearer ${accessToken}`);

        expect(response.statusCode).toBe(200);
        expect(response.body).toHaveProperty('outcomeStatusCode', code);
        expect(response.body).toHaveProperty('outcomeStatusDescription');
    });

    it('should return 404 for non-existing contact outcome', async () => {
        const nonExistingCode = 9999;
        const response = await request(API_URL)
            .get(`/api/ref-contact-outcomes/${nonExistingCode}`)
            .set('Authorization', `Bearer ${accessToken}`);

        expect(response.statusCode).toBe(404);
    });
});
