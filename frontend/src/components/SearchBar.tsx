import { FormEvent, useState } from 'react';
import { useNavigate } from 'react-router-dom';
import styled from 'styled-components';
interface SearchBarProps {
  onChange: (e: any) => void;
  handleSearch: (e: any) => void;
  searchTerm: string;
}

const SearchBar: React.FC<SearchBarProps> = ({ onChange, handleSearch, searchTerm }) => {

  return (
    <SearchBarContainer>
      <SearchInput value={searchTerm} onChange={onChange} type="text" placeholder="Search..." />
      <SearchButton onClick={handleSearch}>Search</SearchButton>
    </SearchBarContainer>
  );
};

export default SearchBar;
const SearchBarContainer = styled.div`
  display: flex;
  align-items: center;
  padding: 8px;
  background-color: #f2f2f2;
  border-radius: 4px;
`;

const SearchInput = styled.input`
  flex: 1;
  border: none;
  outline: none;
  padding: 4px;
`;

const SearchButton = styled.button`
  margin-left: 8px;
  padding: 4px 8px;
  background-color: #007bff;
  color: #fff;
  border: none;
  border-radius: 4px;
  cursor: pointer;
`;