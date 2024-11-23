const request = require('supertest');
const getAccessToken = require('./getAccessToken'); 

const API_URL = 'http://localhost:3001'; 

describe('CustomerProductHoldingsController', () => {
    let accessToken;
    
    beforeAll(async () => {
        accessToken = await getAccessToken();
    });
    
    it('should return a list of customer-product holdings', async () => {
        const response = await request(API_URL)
            .get('/api/customer-product-holdings')
            .set('Authorization', `Bearer ${accessToken}`); 

        expect(response.statusCode).toBe(200);
        expect(Array.isArray(response.body)).toBe(true); 
        if (response.body.length > 0) {
            expect(response.body[0]).toHaveProperty('customerId');
            expect(response.body[0]).toHaveProperty('productId');
            expect(response.body[0]).toHaveProperty('productName');
        }
    });
    
    it('should return details of a specific customer-product holding', async () => {
        const customerId = 1; 
        const productId = 1; 

        const response = await request(API_URL)
            .get(`/api/customer-product-holdings/${customerId}/${productId}`)
            .set('Authorization', `Bearer ${accessToken}`); 

        expect(response.statusCode).toBe(200);
        expect(response.body).toHaveProperty('customerId', customerId);
        expect(response.body).toHaveProperty('productId', productId);
        expect(response.body).toHaveProperty('dateAcquired');
        expect(response.body).toHaveProperty('dateDiscontinued');
        expect(response.body).toHaveProperty('productName');
        expect(response.body).toHaveProperty('productDetails');
    });
    
    it('should return 404 for non-existing customer-product holding', async () => {
        const nonExistingCustomerId = 9999; 
        const nonExistingProductId = 9999;

        const response = await request(API_URL)
            .get(`/api/customer-product-holdings/${nonExistingCustomerId}/${nonExistingProductId}`)
            .set('Authorization', `Bearer ${accessToken}`);

        expect(response.statusCode).toBe(404);
    });
});
