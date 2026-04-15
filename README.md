# Audio Library Manager

## Description

A console application for managing a music track library with multilingual support.

## Features

- Create, view, sort, and delete tracks
- Load/save track library to JSON files
- Input validation (BPM range: 0-300, string length limits, file path verification)
- Delete confirmation to prevent data loss
- Three language modes: English, Czech, and Augur

## How to Use

1. Run the application
2. Choose language (default: English)
3. Select menu option (1-7)
4. Provide valid inputs as requested

## File Structure

- Tracks are stored in `[Music]/AudioLib/library.json`
- Each track contains: Title, Author, BPM

## Notes

Parts of error handling, input validation and styling were created with AI assistance. (Github Copilot)
