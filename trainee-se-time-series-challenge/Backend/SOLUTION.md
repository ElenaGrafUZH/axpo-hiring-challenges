## Solution Challenge 3: Backend

# Hiring Challenge: REST API Documentation

## Base URL

The base URL for accessing the API is: 'https://localhost:{port}/api'

## Endpoints

### Get All Assets

- Method: GET
- URL: '/asset'
- Description: Retrieve a list of all assets from the provided data file.
- Response:
  - Status Code: 200 (OK)
  - Content-Type: application/json
  - Body: array of asset objects, each containing the asset's details

### Get All Signals for a given Asset

- Method: GET
- URL: '/signal/{AssetId}
- Parameter:
  - '**AssetId**': type integer
- Description: Retrieve a list of all signals for a given assets from the provided data file.

* Response:
  - Status Code: 200 (OK)
  - Content-Type: application/json
  - Body: array of signal objects belonging to defined asset, each containing the signal's details

### Get All Measurements for a given Signal with start and end date

- Method: GET
- URL: '/measurement/{SignalId}/{StartDateTime}/{EndDateTime}
- Parameter:
  - '**SignalId**': type integer
  - '**StartDateTime**': type DateTime -> input format 'yyy-MM-dd HH:mm:ss'
  - '**EndDateTime**': type DateTime -> input format 'yyy-MM-dd HH:mm:ss'
- Description: Retrieve a list of all measurements for a given signal in a specific time range from the provided data file.

* Response:
  - Status Code: 200 (OK)
  - Content-Type: application/json
  - Body: array of measurements objects belonging to defined signal and lying in specified time range, each containing the measurement's details
