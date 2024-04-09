extern crate wasm_bindgen;
use wasm_bindgen::prelude::*;

#[wasm_bindgen]
pub fn compress_image(data: Vec<u8>) -> Vec<u8> {
    let compressed_data = data.into_iter().map(|byte| byte / 2).collect();
    compressed_data
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn test_compress_image() {
        let input_data: Vec<u8> = vec![100, 200, 150, 75, 25];
        let expected_compressed_data: Vec<u8> = vec![50, 100, 75, 37, 12];
        let result = compress_image(input_data.clone());
        assert_eq!(result, expected_compressed_data);
    }
}
