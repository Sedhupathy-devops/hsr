package com.emids.da.repository;

import com.emids.da.model.ReviewType;
import com.emids.da.repository.AbstractRepository;
import com.google.inject.persist.Transactional;
import lombok.extern.slf4j.Slf4j;

@Slf4j
@Transactional
public class ReviewTypeRepository extends AbstractRepository<ReviewType> {

  @Override
  public ReviewType findById(Long id) {
    return find(ReviewType.class, id);
  }
}
