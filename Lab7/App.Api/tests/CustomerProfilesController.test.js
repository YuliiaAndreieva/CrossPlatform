const request = require('supertest');
const getAccessToken = require('./getAccessToken');

const API_URL = 'http://localhost:3001';

describe('CustomerProfilesController', () => {
    let accessToken;
    
    beforeAll(async () => {
        accessToken = await getAccessToken();
    });
    
    it('should return a list of customer profiles', async () => {
        const response = await request(API_URL)
            .get('/api/customer-profiles')
            .set('Authorization', `Bearer ${accessToken}`);

        expect(response.statusCode).toBe(200);
        expect(Array.isArray(response.body)).toBe(true);
        if (response.body.length > 0) {
            expect(response.body[0]).toHaveProperty('customerId');
            expect(response.body[0]).toHaveProperty('customerDetails');
        }
    });
    
    it('should return details of a specific customer profile', async () => {
        const customerId = 1; 
        const response = await request(API_URL)
            .get(`/api/customer-profiles/${customerId}`)
            .set('Authorization', `Bearer ${accessToken}`); 

        expect(response.statusCode).toBe(200);
        expect(response.body).toHaveProperty('customerId', customerId);
        expect(response.body).toHaveProperty('customerDetails');
        expect(response.body).toHaveProperty('customerLoyalties'); 
        expect(Array.isArray(response.body.customerLoyalties)).toBe(true);
    });
    
    it('should return 404 for a non-existing customer profile', async () => {
        const nonExistingCustomerId = 9999; 
        const response = await request(API_URL)
            .get(`/api/customer-profiles/${nonExistingCustomerId}`)
            .set('Authorization', `Bearer ${accessToken}`); 

        expect(response.statusCode).toBe(404);
    });
});
